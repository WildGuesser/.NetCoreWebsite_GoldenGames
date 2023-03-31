using GoldenGames.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoldenGames.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GoldenGames.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GoldenGames.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext dbContext,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //Dar acesso a minha view a lista das minhas categorias
            IList<Categorium> categorias = _dbContext.Categoria.ToList();
            ViewData["Categorias"] = categorias;

            IList<Consola> consolas = _dbContext.Consolas.ToList();
            ViewData["Consolas"] = consolas;

            IList<Jogo> jogos = _dbContext.Jogos.ToList();
            ViewData["Jogos"] = jogos;

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> FilterGames(int IdCategoria)
        { 
             string NameCategoria = _dbContext.Categoria.FirstOrDefaultAsync(x => x.Id == IdCategoria).Result.Nome;
            //Vai nos devolver uma lista de jogos com a categoria escolhida
            List<Jogo> resultGamesByCategoria = await _dbContext.Jogos.Where(x => x.IdCategoria == IdCategoria).ToListAsync();


            //Carregar a listas essenciais para voltar a construir a pagina
            IList<Consola> consolas = _dbContext.Consolas.ToList();
            ViewData["Consolas"] = consolas;

            IList<Categorium> categorias = _dbContext.Categoria.ToList();
            ViewData["Categorias"] = categorias;

            if (resultGamesByCategoria != null)
            {
                IList<Jogo> jogos = resultGamesByCategoria.ToList();
                ViewData["Jogos"] = jogos;

                TempData["Success"] = "Jogos pertencentes à categoria: " + NameCategoria;

                return View("Index");
            }
            else
            {
                IList<Jogo> jogos = _dbContext.Jogos.ToList();
                ViewData["Jogos"] = jogos;
                TempData["NoSuccess"] = "Não existem jogos com a categoria: " + NameCategoria;

                return View("Index", jogos);
            }
            return NotFound();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> FilterConsola(int IdConsola)
        {
            string NameConsola = _dbContext.Consolas.FirstOrDefaultAsync(x => x.Id == IdConsola).Result.Nome;
            //Vai nos devolver uma lista de jogos com a categoria escolhida
            List<Jogo> resultGamesByCategoria = await _dbContext.Jogos.Where(x => x.IdConsola == IdConsola).ToListAsync();


            //Carregar a listas essenciais para voltar a construir a pagina
            IList<Consola> consolas = _dbContext.Consolas.ToList();
            ViewData["Consolas"] = consolas;

            IList<Categorium> categorias = _dbContext.Categoria.ToList();
            ViewData["Categorias"] = categorias;

            if (resultGamesByCategoria != null)
            {
                IList<Jogo> jogos = resultGamesByCategoria.ToList();
                ViewData["Jogos"] = jogos;

                TempData["Success"] = "Jogos pertencentes à plataforma: " + NameConsola;

                return View("Index");
            }
            else
            {
                IList<Jogo> jogos = _dbContext.Jogos.ToList();
                ViewData["Jogos"] = jogos;
                TempData["NoSuccess"] = "Não existem jogos com a plataforma: " + NameConsola;

                return View("Index");
            }
            return NotFound();
        }

        public IActionResult Biblioteca()
        {
            return View();
        }


        //Função de teste, estou a tentar descobrir como vou buscar o valor das 
        //categorias escolhidas pelo utilizador
        public ActionResult GetSelectedItems(string listViewId)
        {
            var listView = HtmlHelper.ObjectToDictionary(listViewId);

            var selectedItems = listView.Values;

            return (null);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}