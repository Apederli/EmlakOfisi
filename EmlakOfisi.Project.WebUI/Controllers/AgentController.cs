using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.Entity.Concrete;
using EmlakOfisi.Project.WebUI.Attiributes;
using EmlakOfisi.Project.WebUI.Utilities;
using EmlakOfisi.Project.WebUI.ViewModel;
using Microsoft.AspNetCore.Http;

namespace EmlakOfisi.Project.WebUI.Controllers
{
    [Route("")]
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        private readonly IAdvertisementService _advertisementService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUtilities _utilities;

        public AgentController(IAgentService agentService, IHttpContextAccessor httpContextAccessor, IAdvertisementService advertisementService, IUtilities utilities)
        {
            _agentService = agentService;
            _httpContextAccessor = httpContextAccessor;
            _advertisementService = advertisementService;
            _utilities = utilities;
        }

        [Route("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Login(Agent agent)
        {
            if (agent != null)
            {
                var loginAgent = _agentService.Login(agent);

                if (loginAgent != null)
                {
                    _httpContextAccessor.HttpContext?.Session.SetString("userId", loginAgent.Id.ToString());

                    return RedirectToAction("List", "Advertisement", agent);
                }
            }

            return View();
        }
        [AgentNeeded]
        [Route("update")]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Agent model)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var userId = _httpContextAccessor.HttpContext.Session.GetString("userId");

                var agent = _agentService.GetById(Convert.ToInt32(userId));

                ModelState.Remove("CompanyName");

                ModelState.Remove("Username");

                if (ModelState.IsValid)
                {
                    if (agent != null)
                    {
                        agent.Password = model.Password;

                        _agentService.Update(agent);

                        return RedirectToAction("List", "Advertisement");
                    }
                }

            }

            return View();
        }

    }
}
