using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Practica_1.Models;

namespace Practica_1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
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

    [HttpPost]
        public IActionResult Convertir(ErrorViewModel.MonedaModel model)
        {
            if (ModelState.IsValid)
            {
                decimal tasaCambio = 1.0m;
                if (model.MonedaOrigen == "BRL" && model.MonedaDestino == "PEN")
                    tasaCambio = 0.634m;
                else if (model.MonedaOrigen == "BRL" && model.MonedaDestino == "USD")
                    tasaCambio = 0.174m;
                else if (model.MonedaOrigen == "USD" && model.MonedaDestino == "PEN")
                    tasaCambio = 3.652m;
                else if (model.MonedaOrigen == "USD" && model.MonedaDestino == "BRL")
                    tasaCambio = 5.762m;
                else if (model.MonedaOrigen == "PEN" && model.MonedaDestino == "USD")
                    tasaCambio = 0.274m;
                else if (model.MonedaOrigen == "PEN" && model.MonedaDestino == "BRL")
                    tasaCambio = 1.578m;
                
                model.MontoRecibido = model.MontoEnviado * tasaCambio;
                return View("Confirmar", model);
            }
            return View("Index", model);
        }
}
