using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Noticias.Models;

namespace Noticias.Controllers
{
    public class RotasController : Controller
    {
        // GET: Rotas
        private readonly IEnumerable<Noticia> todasAsNoticias;

        public RotasController()
        {
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
        }

        public ActionResult Index()
        {
            var ultimasNoticias = todasAsNoticias.Take(3);
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList();


            ViewBag.Categorias = todasAsCategorias;
            return View(ultimasNoticias);
        }

        public ActionResult TodasAsNoticias()
        {
            return View(todasAsNoticias);
        }

        public ActionResult MostraNoticia(int noticiaId, string titulo, string categoria)
        {
            return View(todasAsNoticias.FirstOrDefault(x => x.NoticiaId == noticiaId));
        } 

        public ActionResult MostraCategoria(string categoria)
        {
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.categoria = categoria;
            return View(categoriaEspecifica);
        }
    }
}