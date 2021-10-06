using PlatformDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo.ModelValidations
{
    public class Ticket_EnsureDueDateInTheFutureAttr : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            bool ticketIsNew = ticket != null && ticket.TicketId == null;
            
            if (ticketIsNew)
            {
                if (ticket.DueDate.HasValue && ticket.DueDate <= DateTime.Now)
                {
                    return new ValidationResult("Due date must be in the future");
                }
            }

            return ValidationResult.Success;
        }
    }
}
