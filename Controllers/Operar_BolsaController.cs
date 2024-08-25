using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pc1_progra.Models;

namespace pc1_progra.Controllers
{
    public class Operar_BolsaController : Controller
    {
        private readonly ILogger<Operar_BolsaController> _logger;

        public Operar_BolsaController(ILogger<Operar_BolsaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
[HttpPost]
        public IActionResult Calcular(Operar_Bolsa datos)
        {

            datos.CalcularMontoTotal();

 
            var resultados = datos.GetInstrumentosSeleccionados();

            ViewData["lista_Inversion"] = resultados;
            

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}