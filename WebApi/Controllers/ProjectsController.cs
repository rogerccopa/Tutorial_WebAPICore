using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly BugsContext db;

        public ProjectsController(BugsContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Projects.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = db.Projects.Find(id);

            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpGet]
        // here, route must start with /api to override class level attribute
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTickets(int pId)
        {
            var tickets = db.Tickets.Where(tkt => tkt.ProjectId == pId).ToList();

            if (tickets == null || tickets.Count == 0) return NotFound();

            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();

           return CreatedAtAction(nameof(GetById), 
                new { id = project.ProjectId },
                project
           );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            if (id != project.ProjectId)    return BadRequest();

            db.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.Projects.Find(id) == null)   return NotFound();
                
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);

            if (project == null) return NotFound();


            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }
    }
}
