using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PRT.CrwAPI.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Precision(10, 2)]
        public decimal Precio { get; set; }

        public bool Estado { get; set; } = true;

        public List<ImagenProductoDTO> Imagenes { get; set; }
    }
}
