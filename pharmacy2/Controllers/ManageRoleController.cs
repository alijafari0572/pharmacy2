using BE;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pharmacy2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy2.Controllers
{
    public class ManageRoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;

        public ManageRoleController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(Role_Model model)
        {
            if (ModelState.IsValid)
            {
                var role = new Role();
                role.Name = model.Name;
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded) return RedirectToAction("Index");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null) return NotFound();

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(string id, string name)
        {
            if (string.IsNullOrEmpty(name)) return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            role.Name = name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(role);
        }
    }
}