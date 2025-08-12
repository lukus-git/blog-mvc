using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogGarbi.Models;

namespace BlogGarbi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Mensagem"] = "ola mundo";
        //Criar objetos
        Categoria manga = new();
        manga.Id = 1;
        manga.Nome = "hunter";

        Categoria hunter = new()
        {
            Id = 2,
            Nome = "hunter"
        };

        Categoria eletronicos = new(3, "mangá");
    //fim
    
        List<Postagem> postagens = [
            new(){
                Id = 1,
                Nome = "Falta pouco para o arco da Guerra de Sucessão ser retomado",
                CategoriaId = 1,
                Categoria = manga,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "O mangá de Hunter x Hunter, um dos mais conhecidos e aclamados da indústria, está prestes a retornar! De verdade, desta vez.",
                Texto = "",
                Thumbnail = "/img/1.jpg",
                Foto = "/img/1.jpg"
            },
            
            new(){
                Id = 2,
                Nome = " Em qual arco o mangá parou?",
                CategoriaId = 2,
                Categoria = manga,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "O último hiato de Hunter x Hunter foi anunciado no final de 2022, logo após a publicação do capítulo #400 — que faz parte do nono arco da história, a Guerra da Sucessão.",
                Texto = "",
                Thumbnail = "/img/2.jpg",
                Foto = "/img/2.jpg"
            },
            new(){
                Id = 2,
                Nome = "Quando o mangá retorna?",
                CategoriaId = 2,
                Categoria = manga,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "A editora Shueisha afirma que o mangá de Hunter x Hunter retorna no dia 7 de outubro, com o capítulo #401 sendo publicado na 45ª edição da revista Weekly Shonen Jump, no Japão.",
                Texto = "",
                Thumbnail = "/img/3.jpg",
                Foto = "/img/3.jpg"
            },
            new(){
                Id = 3,
                Nome = "E o anime?",
                CategoriaId = 3,
                Categoria = manga,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "Existem dois animes de Hunter x Hunter, e a diferença entre eles é que um cobriu mais arcos do mangá do que o outro. Além de, é claro, o estúdio e a época de produção.",
                Texto = "",
                Thumbnail = "/img/4.jpg",
                Foto = "/img/4.jpg"
            }
        ];
        

        return View(postagens);
    }

    public IActionResult Postagem()
    {
        return View();
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
