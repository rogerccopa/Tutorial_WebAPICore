using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlatformDemo.Models;

namespace PlatformDemo.Filters
{
    public class Ticket_EnsureEnteredDate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;

            if (ticket != null && 
                !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (ticket.EnteredDate.HasValue == false)
                {
                    // indicate the field key  "ticket" for the error
                    context.ModelState.AddModelError("ticket", "EnteredDate is required");

                    // short-circut the pipeline flow (AddErrorModel)
                    // note: if we set/return a Result, that means we are short-circuiting the pipeline
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (ticket.DueDate.HasValue &&
                    ticket.DueDate < ticket.EnteredDate)
                {
                    context.ModelState.AddModelError("ticket", "DueDate cannot be earlier than EnteredDate");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
