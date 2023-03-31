using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoldenGames.Data;
using GoldenGames.Models;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.Security.Claims;
using GoldenGames.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;

namespace GoldenGames.Controllers
{
    [Authorize]
    public class FavCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public FavCategoriesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                ModelState.AddModelError("", "Utilizador não encontrado");
                return RedirectToAction("Index", "Home");
            }

            var favCategories = await _context.FavCategories
                .Include(f => f.IdCategoriaNavigation)
                .Where(f => f.UserId == userId)
                .ToListAsync();

            ViewData["categories"] = _context.Categoria.ToList();

            return View(favCategories);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(string SelectedCategory)
        {
   

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                ModelState.AddModelError("", "Utilizador não encontrado");
                return RedirectToAction("Index", "Home");
            }

            var selectedCategory = _context.Categoria.FirstOrDefault(c => c.Nome == SelectedCategory);
            if (selectedCategory == null)
            {
                ModelState.AddModelError("", "Categoria selecionada não encontrada");
                return RedirectToAction("Index");
            }

            var existingFavCategory = await _context.FavCategories.FirstOrDefaultAsync( f => f.UserId == userId && f.IdCategoria == selectedCategory.Id);
            if (existingFavCategory != null)
            {
                ModelState.AddModelError("", "Categoria já adicionada como favorita");
                return RedirectToAction("Index");
            }

            var favCategory = new FavCategories 
            { 
                UserId = userId, 
                IdCategoria = selectedCategory.Id, 
                IdCategoriaNavigation = selectedCategory
            };

            _context.FavCategories.Add(favCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                ModelState.AddModelError("", "Utilizador não encontrado");
                return RedirectToAction("Index", "Home");
            }

            var favCategory = await _context.FavCategories
                .FirstOrDefaultAsync(z => z.IdCategoria == id && z.UserId == userId);

            if (favCategory == null)
            {
                return NotFound();
            }

            _context.FavCategories.Remove(favCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }   
}
