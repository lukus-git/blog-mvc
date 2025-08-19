using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogGarbi.Models;

namespace BlogGarbi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private List<Postagem> postagens;
    private List<Categoria> categorias; 

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        categorias =[
            new(){ Id = 1, Nome = "Mangá"},
            new(){ Id = 2, Nome = "Anime"},
        ];
    
        postagens = [
            new(){
                Id = 1,
                Nome = "Falta pouco para o arco da Guerra de Sucessão ser retomado",
                CategoriaId = 1,
                Categoria = categorias.Find(c => c.Id ==1),
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "O mangá de Hunter x Hunter, um dos mais conhecidos e aclamados da indústria, está prestes a retornar! De verdade, desta vez.",
                Texto = "Falta pouco para o arco da Guerra de Sucessão em Hunter x Hunter ser retomado, alimentando a expectativa dos fãs após o longo hiato iniciado no final de 2022, com o capítulo #400. O arco, marcado por intrigas, batalhas psicológicas e a disputa brutal pelo trono de Kakin, promete voltar com força total. Com indícios recentes de que Yoshihiro Togashi retomou os trabalhos, a continuação parece cada vez mais próxima.",
                Thumbnail = "/img/1.jpg",
                Foto = "/img/1.jpg"
            },
            
            new(){
                Id = 2,
                Nome = " Em qual arco o mangá parou?",
                CategoriaId = 1,
                Categoria =categorias.Find(c => c.Id ==1),
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "O último hiato de Hunter x Hunter foi anunciado no final de 2022, logo após a publicação do capítulo #400 — que faz parte do nono arco da história, a Guerra da Sucessão.",
                Texto = "O mangá Hunter x Hunter entrou em mais um hiato após a publicação do capítulo #400, no final de 2022. Esse capítulo marcou um ponto crucial no arco da Guerra de Sucessão, que vem se desenrolando com tensão e complexidade política. A pausa, embora frustrante para os fãs, reflete o compromisso do autor Yoshihiro Togashi com sua saúde e com a qualidade da obra. Ainda sem data oficial para o retorno, o público segue aguardando ansiosamente os próximos desdobramentos da trama.",
                Thumbnail = "/img/2.jpg",
                Foto = "/img/2.jpg"
            },
            new(){
                Id = 3,
                Nome = "Quando o mangá retorna?",
                CategoriaId = 1,
                Categoria =categorias.Find(c => c.Id ==1),
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "A editora Shueisha afirma que o mangá de Hunter x Hunter retorna no dia 7 de outubro, com o capítulo #401 sendo publicado na 45ª edição da revista Weekly Shonen Jump, no Japão.",
                Texto = "O mangá Hunter x Hunter vai voltar oficialmente no dia 7 de outubro de 2024, com o capítulo 401 sendo publicado na 45ª edição da revista Weekly Shonen Jump no Japão. Essa pausa durou quase dois anos, deixando os fãs na expectativa. Agora, o autor Yoshihiro Togashi e a editora Shueisha decidiram que os capítulos não sairão mais toda semana, para que ele possa trabalhar com mais calma e cuidar da saúde. Esse retorno marca um momento muito aguardado para quem acompanha a série e espera pelos próximos capítulos da Guerra de Sucessão.",
                Thumbnail = "/img/3.jpg",
                Foto = "/img/3.jpg"
            },
            new(){
                Id = 4,
                Nome = "E o anime?",
                CategoriaId = 2,
                Categoria = categorias.Find(c => c.Id ==2),
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "Existem dois animes de Hunter x Hunter, e a diferença entre eles é que um cobriu mais arcos do mangá do que o outro. Além de, é claro, o estúdio e a época de produção.",
                Texto = "Hunter x Hunter possui duas adaptações em anime, cada uma com suas particularidades. A primeira, de 1999, foi produzida pelo estúdio Nippon Animation e adaptou até o arco da Greed Island. Já a segunda, lançada em 2011 pelo estúdio Madhouse, cobriu mais arcos do mangá, indo até a conclusão da eleição após a morte de Netero. Além da diferença no conteúdo adaptado, os estilos de animação, trilha sonora e direção também refletem as épocas distintas em que foram produzidos.",
                Thumbnail = "/img/4.jpg",
                Foto = "/img/4.jpg"
            }
        ];
        
    }

    public IActionResult Index()
    {
        return View(postagens);
    }

    public IActionResult Postagem(int id)
    {
        var postagem = postagens
        .Where(p => p.Id == id)
        .SingleOrDefault();
        if (postagem == null)
            return NotFound();
           ViewData["Categorias"] = categorias;
        return View(postagem);
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
