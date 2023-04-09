using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AppCollection.Controllers
{
    [Authorize]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // List All the roles created by users
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View();
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task <IActionResult> Create(IdentityRole model)
        {
            //avoid duplicate role
            if (_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                return RedirectToAction("Index");
            }
            _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            return RedirectToAction("Index");

        }
    }
}
