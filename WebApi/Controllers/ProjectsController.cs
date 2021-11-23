using Microsoft.AspNetCore.Mvc;
using PlatformDemo.Models;
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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all projects");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading project #{id}");
        }

        /// <summary>
        /// e.g. request: https://localhost:5001/api/projects/456/tickets?tid=44&title=MyTitle&Description=MyDesc
        /// </summary>
        /// <param name="pid">Comes in the route</param>
        /// <param name="tid">jComes in the url query</param>
        /// <returns></returns>
        [HttpGet]
        // here, route must start with /api to override class level attribute
        [Route("/api/projects/{pid}/tickets")]
        // by default, .net core will search complex types (i.e. Ticket) in the Body so,
        // we must indicate that it comes in URL query params
        public IActionResult GetProjectTicket([FromQuery] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Parameters are not provided properly!");
            }

            if (ticket.TicketId == 0)
            {
                return Ok($"Reading all tickets that belong to project #{ticket.ProjectId}");
            }

            return Ok($"Reading project #{ticket.ProjectId}, ticket #{ticket.TicketId}, Title:{ticket.Title}, Desc: {ticket.Description}");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Creating a new project");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Updating a project");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting project {id}");
        }
    }
}
