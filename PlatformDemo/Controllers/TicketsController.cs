using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo.Controllers
{
    [ApiController]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        [Route("api/tickets")]
        public IActionResult Get()
        {
            return Ok("Reading all the tickets");
        }

        [HttpGet]
        [Route("api/tickets/{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok($"Reading ticket #{Id}");
        }

        [HttpPost]
        [Route("api/tickets")]
        public IActionResult Create(int Id)
        {
            return Ok("Creating a ticket");
        }

        [HttpPut]
        [Route("api/tickets")]
        public IActionResult Update(int Id)
        {
            return Ok("Updating a ticket");
        }

        [HttpDelete]
        [Route("api/tickets/{id}")]
        public IActionResult Delete(int Id)
        {
            return Ok("Deleting a ticket");
        }
    }
}
