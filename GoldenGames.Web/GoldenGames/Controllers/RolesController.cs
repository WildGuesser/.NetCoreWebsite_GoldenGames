using GoldenGames.Data;
using GoldenGames.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace GoldenGames.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(ILogger<RolesController> logger,
            ApplicationDbContext dbContext,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult ChangeRole()
        {
          
            var userRoleViewModel = new UserRolesViewModel { };
            ViewData["roles"] = _roleManager.Roles.ToList();
            return View("ChangeRole", userRoleViewModel);
          
        }

        //Vai ser usada pelos admins para mudar roles, depois é necessário adicionar authorization aqui
        //Apenas ADMINS pode aceder a toda esta pagina, esta definido em cima do RollesController
        public async Task<ActionResult> GetUser(string findUser)
        {
            ViewData["roles"] = _roleManager.Roles.ToList();
            var user = await _userManager.FindByNameAsync(findUser);

            if (user != null)
            {
                
                var roles = await _userManager.GetRolesAsync(user);
                var userRole = roles.FirstOrDefault();

                var userRoleViewModel = new UserRolesViewModel
                {
                    User = user.UserName,
                    UserRole = userRole
                };

             

                return View("ChangeRole", userRoleViewModel);
            }
            else
            {

                ModelState.AddModelError("", "Utilizador não encontrado");
                return View("ChangeRole");

            }
        }
        [HttpPost]
        public async Task<IActionResult> ChangeRole(string findUser, string selectedRole)
        {
            if (string.IsNullOrEmpty(findUser))
            {
                return View("ChangeRole");
            }
            ViewData["roles"] = _roleManager.Roles.ToList();

            var user = await _userManager.FindByNameAsync(findUser);
            var roles = await _userManager.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault();
            _userManager.RemoveFromRoleAsync(user, userRole).Wait();
            _userManager.AddToRoleAsync(user, selectedRole).Wait();


            var rolefinal = await _userManager.GetRolesAsync(user);
            var userRolefinal = rolefinal.FirstOrDefault();


            var userRoleViewModel = new UserRolesViewModel
            {
                User = user.UserName,
                UserRole = userRolefinal
            };
            return View("ChangeRole", userRoleViewModel);
        }
    }
}
