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
        /// e.g. request: api/projects/{pid}/tickets?tid={tid}
        /// </summary>
        /// <param name="pid">Comes in the route</param>
        /// <param name="tid">jComes in the url query</param>
        /// <returns></returns>
        [HttpGet]
        // here, route must start with /api to override class level attribute
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket(int pid, [FromQuery] int tid)
        {
            // By default .Net core will search tid in the following sequence:
            // 1. Form Fields
            // 2. Request Body
            // 3. Route data
            // 4. URL Query string params

            if (tid == 0)
            {
                return Ok($"Reading all tickets that belong to project #{pid}");
            }

            return Ok($"Reading project #{pid}, ticket #{tid}");
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
