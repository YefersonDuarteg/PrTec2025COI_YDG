using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PRT.CrwAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Precision(10, 2)]
        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = true;

        public ICollection<ImagenProducto>? Imagenes { get; set; }
    }
}
