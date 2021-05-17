using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.Entity.Concrete;
using EmlakOfisi.Project.WebUI.Attiributes;
using EmlakOfisi.Project.WebUI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EmlakOfisi.Project.WebUI.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAgentService _agentService;

        public AdminController(IAdminService adminService, IHttpContextAccessor httpContextAccessor, IAgentService agentService)
        {
            _adminService = adminService;
            _httpContextAccessor = httpContextAccessor;
            _agentService = agentService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Admin admin)
        {
            if (admin != null)
            {
                var loginAdmin = _adminService.Get(admin);

                if (loginAdmin != null)
                {
                    _httpContextAccessor.HttpContext?.Session.SetString("adminId", loginAdmin.Id.ToString());

                    return RedirectToAction("AddAgent");
                }
            }

            return View();
        }
        [AdminNeeded]
        [Route("add-agent")]
        public IActionResult AddAgent()
        {
           

            return View();
        }
        [HttpPost]
        [Route("add-agent")]
        public IActionResult AddAgent(Agent agent)
        {
            if (ModelState.IsValid)
            {
               var userId = _httpContextAccessor.HttpContext?.Session.GetString("adminId");

                Agent addedAgent = new Agent()
                {
                    CompanyName = agent.CompanyName,
                    Username = agent.Username,
                    AddedByAdminId = userId
                };

                _agentService.Add(addedAgent);
                return View();
            }

            return View();
        }
    }
}
