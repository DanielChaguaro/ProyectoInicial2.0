using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoInicial.Models;
using ProyectoInicial.Services;

namespace ProyectoInicial.Controllers
{
    public class InventarioLibrosController : Controller
    {

        private readonly Iconsumo _consumo;

        public InventarioLibrosController(Iconsumo consumo)
        {
            _consumo = consumo;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Libros> libros = await _consumo.GetLibros();
            return View(libros);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdLibro)
        {
            Libros DetalleLibro = new Libros();
            DetalleLibro = await _consumo.GetLibro(IdLibro);
            if (DetalleLibro != null)
            {
                return View(DetalleLibro);
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Libros libro)
        {
            
                Libros libroCreado = await _consumo.PostLibro(libro);
                return RedirectToAction("Index");
            
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdLibro)
        {
            
            Libros libroEditado = await _consumo.GetLibro(IdLibro);
            return View(libroEditado);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Libros libro)
        {
            //try
            //{
            if (libro.IdLibro == 0)
            {
                Libros libroEditado = await _consumo.PostLibro(libro);
            }
            else
            {
                Libros libroEditado = await _consumo.PutLibro(libro.IdLibro, libro);

            }
            return RedirectToAction("Index");
            
        }



        [HttpGet]
        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdLibro)
        {
            
                string result = await _consumo.DeleteLibro(IdLibro);
                return RedirectToAction("Index");
           
             
        }



    }
}
