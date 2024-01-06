using System.ComponentModel.DataAnnotations;

namespace ProyectoInicial.Models
{
    public class Usuario
    {
     
        public int IdUsuario { get; set; }
        
        public string Nombre { get; set; }
        
        public string Apellido { get; set; }
        
        public string Perfil { get; set; }
        
        public string UsuarioP { get; set; }
        
        public string Contrasena { get; set; }
    }
}
