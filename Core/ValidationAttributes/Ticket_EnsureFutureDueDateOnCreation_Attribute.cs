using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    class Ticket_EnsureFutureDueDateOnCreation_Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateFutureDueDate())
            {
                return new ValidationResult("Due date must be in the future");
            }

            return ValidationResult.Success;
        }
    }
}
