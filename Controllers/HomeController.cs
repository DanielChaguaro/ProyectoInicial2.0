using ProyectoInicial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using ProyectoInicial.Services;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly Iconsumo _consumo;

        public HomeController(Iconsumo consumo)
        {
            _consumo = consumo;
        }


        public IActionResult Index()
        {
            return View();
        }

        

        
    }
}