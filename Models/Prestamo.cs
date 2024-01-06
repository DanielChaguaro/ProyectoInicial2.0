using System.ComponentModel.DataAnnotations;

namespace ProyectoInicial.Models
{
    public class Prestamo
    {
        
        public int IdPrestamo { get; set; }
        
        public int IdProducto { get; set; }
        
        public int Cantidad { get; set; }
       
        public int PrecioUnitario { get; set; }
        
        public int Total
        {
            get { return Cantidad * PrecioUnitario; }
        }
    }
}
