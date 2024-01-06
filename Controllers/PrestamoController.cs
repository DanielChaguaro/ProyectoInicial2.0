using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoInicial.Models;
using ProyectoInicial.Services;

namespace ProyectoInicial.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly Iconsumo _consumo;

        public PrestamoController(Iconsumo consumo)
        {
            _consumo = consumo;
        }


        public async Task<IActionResult> Index()
        {
            List<Prestamo> prestamo = await _consumo.GetPrestamos();
            return View(prestamo);
        }

        public async Task<IActionResult> Details(int IdPrestamo)
        {
            Prestamo DetallePrestamo = new Prestamo();
            DetallePrestamo = await _consumo.GetPrestamo(IdPrestamo);
            if (DetallePrestamo != null)
            {
                return View(DetallePrestamo);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Prestamo prestamo)
        {
            Libros libroPrestado = await _consumo.GetLibro(prestamo.IdProducto);
            prestamo.PrecioUnitario = libroPrestado.precio;
            if (prestamo.Cantidad <= libroPrestado.cantidad)
            {
                libroPrestado.cantidad = libroPrestado.cantidad - prestamo.Cantidad;
                
                await _consumo.PutLibro(libroPrestado.IdLibro, libroPrestado);
                Prestamo prestamoCreado = await _consumo.PostPrestamo(prestamo);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            

        }

        public async Task<IActionResult> Edit(int IdPrestamo)
        {

            Prestamo prestamoEditado = await _consumo.GetPrestamo(IdPrestamo);
            return View(prestamoEditado);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Prestamo prestamo)
        {
            
            if (prestamo.IdPrestamo == 0)
            {
                Prestamo prestamoEditado = await _consumo.PostPrestamo(prestamo);
            }
            else
            {
                Prestamo prestamoEditado = await _consumo.PutPrestamo(prestamo.IdPrestamo,prestamo);
               

            }
            return RedirectToAction("Index");

        }



        [HttpGet]

        public async Task<IActionResult> Delete(int IdPrestamo)
        {

            string result = await _consumo.DeletePrestamo(IdPrestamo);
            return RedirectToAction("Index");


        }

    }
}
