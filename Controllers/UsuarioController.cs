using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoInicial.Models;
using ProyectoInicial.Services;

namespace ProyectoInicial.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Iconsumo _consumo;

        public UsuarioController(Iconsumo consumo)
        {
            _consumo = consumo;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Usuario> usuarios = await _consumo.GetUsuarios();
            return View(usuarios);
        }

        // GET: ProductoController/Details/5
        /*public async Task<IActionResult> Details(int IdUsuario)
        {
            Usuario DetalleUsuario = new Usuario();
            DetalleUsuario = await _consumo.GetUsuario(IdUsuario);
            if (DetalleUsuario != null)
            {
                return View(DetalleUsuario);
            }
            return RedirectToAction("Index");
        }*/

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            List<Usuario> usuarios=await _consumo.GetUsuarios();
            bool credencialesValidas = usuarios.Any(u => u.UsuarioP == usuario.UsuarioP );

            if (credencialesValidas)
            {
                //ViewData["Mensaje"] = "No se pudo crear el usuario";
                return View();
            }
            else
            {
                Usuario usuarioCreado = await _consumo.PostUsuario(usuario);
                return RedirectToAction("Index");

            }
        }
        public async Task<IActionResult> Edit(int IdUsuario)
        {

            Usuario usuarioEditado = await _consumo.GetUsuario(IdUsuario);
            return View(usuarioEditado);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            //try
            //{
            if (usuario.IdUsuario == 0)
            {
                Usuario usuarioEditado = await _consumo.PostUsuario(usuario);
            }
            else
            {
                Usuario usuarioEditado = await _consumo.PutUsuario(usuario.IdUsuario, usuario);

            }
            return RedirectToAction("Index");

        }



        [HttpGet]

        public async Task<IActionResult> Delete(int IdUsuario)
        {

            string result = await _consumo.DeleteUsuario(IdUsuario);
            return RedirectToAction("Index");


        }


    }
}
