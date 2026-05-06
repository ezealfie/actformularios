using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ActividadFormularios.Models;

namespace ActividadFormularios.Controllers;

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
    [HttpPost] 
  public IActionResult Solicitud(string nombre, int edad, int dni, int trabaja, int tipoempleo, int ingreso, int deudas, bool credito, bool bancario, bool informal, int monto, int plazo, string terminos)
    {   bool aprobado;

        if (edad < 18 || trabaja == 2 || tipoempleo == 4 || ingreso < 250000 || monto > ingreso/5 || deudas == 1 || terminos != "on")
        {
            aprobado = false;
        }
        else aprobado = true;
        ViewBag.estado = aprobado;

        return View("infoSolicitud");
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
