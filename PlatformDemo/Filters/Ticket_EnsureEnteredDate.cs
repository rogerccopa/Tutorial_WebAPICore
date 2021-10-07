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

            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner) && ticket.EnteredDate.HasValue == false)
            {
                // inticate the field key  "ticket" for the error
                context.ModelState.AddModelError("ticket", "EnteredDate is required");
                // short-circut the pipeline flow (AddErrorModel)
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
