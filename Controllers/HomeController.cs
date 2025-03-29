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
        public IActionResult GuardarDatos(string nombre, string documento, ErrorViewModel.MonedaModel model)
        {
            var confirmacion = new ErrorViewModel.ConfirmacionModel
            {
                Nombre = nombre,
                Documento = documento,
                MontoRecibido = model.MontoRecibido,
                MonedaDestino = model.MonedaDestino
            };
            return View("ConfirmacionFinal", confirmacion);
        }
}
