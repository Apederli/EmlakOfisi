using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmlakOfisi.Project.WebUI.Attiributes
{
    public class AgentNeeded : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessionKey = context.HttpContext.Session.GetString("userId");
            if (sessionKey == null)
            {
                context.Result = new RedirectToActionResult("Login", "Agent", new { });
            }
        }
    }
}
