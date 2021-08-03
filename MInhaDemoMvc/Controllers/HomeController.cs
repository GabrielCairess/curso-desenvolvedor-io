using Microsoft.AspNetCore.Mvc;
using MInhaDemoMvc.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace MInhaDemoMvc.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {

        [Route("")]
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id?}")]
        [Route("pagina-inicial/{id:int}/{categoria?}")]
        public IActionResult Index(int id, string categoria)
        {
            var filme = new Filme() 
            { 
                Titulo = "Oi",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000
            };

            //return RedirectToAction("Privacy", filme);
            return View();
        }

        [Route("sobre")]
        [Route("sobre/{categoria:guid}")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("privacidade")]
        [Route("politica-privacidade")]
        public IActionResult Privacy(Filme filme)
        {
            //var fileBytes = System.IO.File.ReadAllBytes(@"C:\Teste\arquivo.txt");
            //var fileName = "arquivo.txt";

            if (!ModelState.IsValid)
            {
                return Json(ModelState.Values.SelectMany(m => m.Errors));
            } else 
                return View();
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
