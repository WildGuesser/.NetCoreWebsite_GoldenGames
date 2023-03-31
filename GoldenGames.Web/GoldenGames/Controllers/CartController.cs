using Microsoft.AspNetCore.Mvc;
using GoldenGames.Models;
using GoldenGames.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Xml.Schema;

namespace GoldenGames.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {

            var cartData = HttpContext.Request.Cookies["cart"];
            if (cartData == null)
            {
                return View(new List<JogosCompra>());
            }

            var gameIds = JsonConvert.DeserializeObject<List<int>>(cartData);

            var games = await _context.Jogos
                .Where(j => gameIds.Contains(j.Id))
                .ToListAsync();

            var items = games.Select(j => new JogosCompra { IdJogoNavigation = j }).ToList();

            return View(items);
        }


      

        public async Task<IActionResult> AddToCart(int? gameid)
        {
            if (gameid == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos.FindAsync(gameid);
            if (jogo == null)
            {
                return NotFound();
            }

            var cartData = HttpContext.Request.Cookies["cart"];
            List<int> gameIds;

            if (cartData == null)
            {
                gameIds = new List<int> { jogo.Id };
            }
            else
            {
                gameIds = JsonConvert.DeserializeObject<List<int>>(cartData);

                if (!gameIds.Contains(jogo.Id))
                {
                    gameIds.Add(jogo.Id);
                }
            }

            // Serializaçãp
            cartData = JsonConvert.SerializeObject(gameIds);
            HttpContext.Response.Cookies.Append("cart", cartData);

            TempData["message"] = "Item adicionado ao carrinho!";

            //Retorna para quem chama
            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }


        public async Task<IActionResult> Remove(int? gameid)
        {
            if (gameid == null)
            {
                return NotFound();
            }

            var cartData = HttpContext.Request.Cookies["cart"];
            if (cartData == null)
            {
                return NotFound();
            }

            var gameIds = JsonConvert.DeserializeObject<List<int>>(cartData);
            // Remove o gameid da lista
            gameIds.Remove((int)gameid);

            // Serialize the updated cart data and set it in a cookie
            cartData = JsonConvert.SerializeObject(gameIds);
            HttpContext.Response.Cookies.Append("cart", cartData);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Checkout()
        {
            var cartData = HttpContext.Request.Cookies["cart"];
            if (cartData == null)
            {
                return View(new List<JogosCompra>());
            }

            // Deserialize the cart data
            var gameIds = JsonConvert.DeserializeObject<List<int>>(cartData);

            var games = await _context.Jogos
                .Where(j => gameIds.Contains(j.Id))
                .ToListAsync();

            decimal totalPrice = (decimal)games.Sum(g => g.Preco);

            var user = await GetCurrentUserAsync();
            string userId = user.Id;
            string userName = user.UserName;

            //beacause my computer is garbish
            int counterCompras = _context.Compras.Count();

            var compra = new Compra
            {

                UserId = userId,
                UserName = userName,
                Total_Preco = totalPrice
            };

            var items = games.Select(j => new JogosCompra { IdJogoNavigation = j }).ToList();
            compra.JogosCompras = items;

          
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            // Limpar cookie
            HttpContext.Response.Cookies.Delete("cart");

            return RedirectToAction("ShowCompra", "Cart", new { id = compra.Id });

        }

        public async Task<IActionResult> ShowCompra(int id)
        {
            var compra = await _context.JogosCompras.Include(j => j.IdJogoNavigation)
                .Where(c => c.IdCompra == id).ToListAsync();

            if (compra == null)
            {
                return NotFound();
            }


            var t =  await _context.Compras.SingleOrDefaultAsync(x => x.Id == id);
            var total = t.Total_Preco;
            
            ViewBag.total = total;
            return View(compra);
        }
    }
}
