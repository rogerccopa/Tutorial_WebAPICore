using Microsoft.AspNetCore.Mvc;
using PlatformDemo.Filters;
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
            // Authentication & authorization
            // Generic validation
            // Retrieve the input data (model biding)
            // Data validation
            // Application logic/data (developer focus on this area)
            // Format output data
            // Exception handling

            // middlewares act globally (they cannot apply only to certain action methods)
            // filters can be applied to specific action methods or be applied to global controllers

            return Ok("Reading all the tickets");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok($"Reading ticket #{Id}");
        }

        [HttpPost]
        public IActionResult CreateV1([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpPost]
        [Route("/api/v2/tickets")]
        [Ticket_EnsureEnteredDate]
        public IActionResult CreateV2([FromBody] Ticket ticket)
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
