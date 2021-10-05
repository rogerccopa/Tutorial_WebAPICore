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
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the tickets");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok($"Reading ticket #{Id}");
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpPut]
        public IActionResult Update(Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            return Ok("Deleting a ticket");
        }
    }
}
