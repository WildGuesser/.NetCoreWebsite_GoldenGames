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
using GoldenGames.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Helpers.Mail;
using Bogus;
using System.Diagnostics.Metrics;

namespace GoldenGames.Controllers
{
    public class InfoProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public InfoProductController(ApplicationDbContext dbContext, 
            UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _emailSender = emailSender;

        }

        // GET: InfoProduct
        //A página Index tem como propósito mostrar o resultado do jogo que o utilizador deu click
        [AllowAnonymous]
        public async Task<IActionResult> Index(int Id)
        {
            //Vamos pesquisar a base de dados o jogo escolhido atrvés do Id passado
            var gameResult = await _dbContext.Jogos.FirstOrDefaultAsync(x => x.Id == Id);

            var game = await _dbContext.Jogos
                .Include(g => g.Reviews)
                .FirstOrDefaultAsync(g => g.Id == Id);

            if (gameResult == null)
            {
                return NotFound();
            }
            else
            {
                List<Jogo> jogo = new List<Jogo>();
                
                //Vamos criar um objeto que contenha toda a informação relacionada com o jogo
                //Para enviarmos essa informação para a view e apresentá-la
                Jogo _jogo = new Jogo
                {
                    Id = gameResult.Id,
                    Nome = gameResult.Nome,
                    Descricao = gameResult.Descricao,
                    Produtora = gameResult.Produtora,
                    Preco = gameResult.Preco,
                    Imagem = gameResult.Imagem
                };
                jogo.Add(_jogo);

                //O nosso IdConsolaNavigation n esta a funcionar corretamente, estou a fazer alguma merda de errado
                //Pelo motivo de avançar dado o curto espaço de tempo vou ter de deixar assim
                string nomeCategoria = _dbContext.Categoria.FirstOrDefaultAsync(x => x.Id == gameResult.IdCategoria).Result.Nome;
                string nomeConsola = _dbContext.Consolas.FirstOrDefaultAsync(x => x.Id == gameResult.IdConsola).Result.Nome;

                ViewBag.Imagem = gameResult.Imagem;
                ViewBag.NomeConsola = nomeConsola;
                ViewBag.NomeCategoria = nomeCategoria;

                ViewData["Jogo"] = jogo;
                ViewData["Reviews"] = game.Reviews;
            }
            return View(gameResult);
        }

        // GET: InfoProduct/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbContext.Jogos == null)
            {
                return NotFound();
            }

            var jogo = await _dbContext.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // GET: InfoProduct/Create
        [Authorize(Roles = "Admin, Funcionario")]
        public IActionResult Create()
        {
            //Criar a nossa lista com todo o conteúdo presente na base de dados
            IList<Categorium> categorias = _dbContext.Categoria.ToList();
            IList<Consola> consolas = _dbContext.Consolas.ToList();

            //Passar esse conteudo para a view
            ViewData["Categorias"] = categorias;
            ViewData["Consolas"] = consolas;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Funcionario")]
        public async Task<IActionResult> Create(JogoViewModel jogoViewModel)
        {
            byte[] imageArray;

            if (Request.Form.Files.Count > 0)
            {
                //Vamos adicionar a imagem do jogo a DB
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    imageArray = dataStream.ToArray();

                }


                if (ModelState.IsValid)
                {
                    //Vai buscar o utilizador logged in, neste preciso momento
                    var user = await GetCurrentUserAsync();

                    //Vamos verificar se existe na BD a nova entrada
                    var validacaoNome = await _dbContext.Jogos.FirstOrDefaultAsync(x => x.Nome.Equals(jogoViewModel.Nome));

                    //Se não exsite nenhuma entrada
                    if (validacaoNome == null)
                    {
                        /*Estou a colocar isto por preguiça não encontro uma resposta para o meu 
                         porque de me estar a adicionar um elemento sem lhe atribuir um Id automaticamente*/
                        int count = _dbContext.Jogos.Count();

                        //Criar o jogo com os parâmetros inseridos
                        Jogo novoJogo = new Jogo()
                        {

                            Nome = jogoViewModel.Nome,
                            Descricao = jogoViewModel.Descricao,
                            Produtora = jogoViewModel.Produtora,
                            IdCategoria = jogoViewModel.IdCategoria,
                            IdConsola = jogoViewModel.IdConsola,
                            Preco = jogoViewModel.Preco,    
                            Imagem = imageArray,
                        };

                        var result = await _dbContext.Jogos.AddAsync(novoJogo);
                        _dbContext.SaveChanges();

                        /// Fazer o mesmo aqui pk esta acontecer the same bullshit /
                        int countRJ = _dbContext.RegistoJogos.Count();

                        //Registar o jogo agarrado ao Id do utilizador para sabermos quem o adicionou
                        RegistoJogo registoJogo = new RegistoJogo()
                        {

                            IdJogo = novoJogo.Id,
                            IdUtilizador = user.Id
                        };

                        var resultRJ = _dbContext.RegistoJogos.AddAsync(registoJogo);
                        _dbContext.SaveChanges();

                        var users = _dbContext.FavCategories
                            .Where(f => f.IdCategoria == jogoViewModel.IdCategoria)
                            .Select(f => f.IdUtilizadorNavigation)
                            .ToList();

                        var categoria = _dbContext.Categoria
                            .FirstOrDefault(m => m.Id == jogoViewModel.IdCategoria);

                        foreach (var userToEmail in users)
                        {
                            await _emailSender.SendEmailAsync(
                                userToEmail.Email,
                                "Novo jogo disponível",
                                $"Olá {userToEmail.UserName},<br> Um novo jogo da categoria {categoria.Nome} " +
                                $"acabou de ser adicionado à nossa loja." +
                                $" <br> Aproveite para dar uma vista de olhos!");
                        }
                        //Mensagem de sucesso
                        TempData["Success"] = "Jogo adicionado";
                        return RedirectToAction();

                    }
                    else
                    {
                        ModelState.AddModelError("Nome", "Nome introduzido já existe. Insira um nome diferente.");
                    }
                }
                else
                {
                    //Isto não está bem como apresentaçao de erro
                    ModelState.AddModelError("Error", "Model State Not Valid");
                }

            }
            else
            {
                ModelState.AddModelError("Imagem", "Insira uma imagem de capa para o jogo.");
            }

            return RedirectToAction();
        }

        // GET: InfoProduct/Edit/5
        [Authorize(Roles = "Admin, Funcionario")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbContext.Jogos == null)
            {
                return NotFound();
            }

            var jogo = await _dbContext.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_dbContext.Categoria, "Id", "Id", jogo.IdCategoria);
            return View(jogo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, JogoViewModel jogo)
        {
            if (id != jogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(jogo);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_dbContext.Categoria, "Id", "Id", jogo.IdCategoria);
            return View(jogo);
        }

        // GET: InfoProduct/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dbContext.Jogos == null)
            {
                return NotFound();
            }

            var jogo = await _dbContext.Jogos
                .Include(j => j.IdCategoria)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: InfoProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Funcionario")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbContext.Jogos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jogos'  is null.");
            }
            var jogo = await _dbContext.Jogos.FindAsync(id);
            if (jogo != null)
            {
                _dbContext.Jogos.Remove(jogo);
            }
            
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(int id)
        {
          return _dbContext.Jogos.Any(e => e.Id == id);
        }

        [Authorize]
        [Authorize(Roles = "Admin, Funcionario, Cliente")]
        public async Task<IActionResult> CreateReview(int gameId)
        {
            var review = new Review { GameId = gameId };

            return View("CreateReview", review);
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Funcionario, Cliente")]
        public async Task<IActionResult> CreateReview(int gameId, int rating, string content)
        {
            var gameResult = await _dbContext.Jogos.FirstOrDefaultAsync(x => x.Id == gameId);
            var user = await GetCurrentUserAsync();


            if (gameResult != null)
            {
                var Review = new Review
                {
                    Content = content,
                    CreatedAt = DateTime.Now,
                    UserId = user.Id,
                    UserName = user.UserName,
                    GameId = gameId,
                    Rating = rating

                };
                gameResult.Reviews.Add(Review);
                _dbContext.Jogos.Update(gameResult);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { Id = gameId });

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
            var user = await GetCurrentUserAsync();

            if (review == null)
            {
                return NotFound();
            }
            var currentUser = await GetCurrentUserAsync();
            if (review.UserId != user.Id)
            {
                return Content("You can only delete reviews that you created.");
            }
            return View(review);
        }

        [HttpPost, ActionName("DeleteReview")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteReviewConfirmed(int reviewId)
        {
            var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
            var user = await GetCurrentUserAsync();

            if (review == null)
            {
                return NotFound();
            }

            if(!User.IsInRole("Admin"))
            { 
                if (review.UserId != user.Id )
                {
                    return Content("You can only delete reviews that you created.");
                }
            }


            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", new { Id = review.GameId });
        }

    }
}
