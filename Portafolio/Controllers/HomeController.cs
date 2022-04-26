using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Services;
using Portafolio.Servicios;
using System.Diagnostics;

namespace portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, //ayuda a identificar de donde sale el mensaje de log 
            //con Ilogger tambien podemos definir categorias de mensajes hay 6 en total para su prioridad
            //critial, error, warning, information, debug, trace 
            IRepositorioProyectos repositorioProyectos,
            IServicioEmail servicioEmail
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }
        
        

        public IActionResult Index()
        {
            _logger.LogDebug("este es un mensaje de debug");
            _logger.LogTrace("este es un mensaje de trace");
            _logger.LogInformation("este es un mensaje de information");
            _logger.LogWarning("este es un mensaje de warning");
            _logger.LogError("este es un mensaje de error");
            _logger.LogCritical("este es un mensaje de critical");
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos
            };      
            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }
        public IActionResult Gracias()
        {
            return View();
        }
        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}