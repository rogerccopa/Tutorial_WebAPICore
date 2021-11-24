using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
     public class Ticket
    {
        public int? TicketId { get; set; }

        [Required]
        public int? ProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        [StringLength(50)]
        public string Owner { get; set; }

        [Ticket_EnsureReportDatePresent_Attribute]
        public DateTime? ReportDate { get; set; }

        [Ticket_EnsureDueDatePresent_Attribute]
        [Ticket_EnsureFutureDueDateOnCreation_Attribute]
        [Ticket_EnsureDueDateAfterReportDate_Attribute]
        public DateTime? DueDate { get; set; }

        public Project Project { get; set; }

        /// <summary>
        /// when creating a ticket, if DueDate is entered, it has to be in the future
        /// </summary>
        public bool ValidateFutureDueDate()
        {
            if (TicketId.HasValue) return true;
            if (!DueDate.HasValue) return true;

            return (DueDate > DateTime.Now);
        }

        /// <summary>
        /// when Owner is assigned, ReportDate has to be present
        /// </summary>
        public bool ValidateReportDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return ReportDate.HasValue;
        }

        /// <summary>
        /// when Owner is assigned, DueDate has to be present
        /// </summary>
        public bool ValidateDueDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return DueDate.HasValue;
        }

        /// <summary>
        /// when DueDate & ReportDate are present, DueDate must be equal or later then ReportDate
        /// </summary>
        public bool ValidateDueDateAfterReportDate()
        {
            if (!DueDate.HasValue || !ReportDate.HasValue) return true;

            return DueDate.Value.Date >= ReportDate.Value.Date;
        }
    }
}
