﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    class Ticket_EnsureDueDateAfterReportDate_Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateDueDateAfterReportDate())
            {
                return new ValidationResult("Due date has to be after Report date");
            }

            return ValidationResult.Success;
        }
    }
}
