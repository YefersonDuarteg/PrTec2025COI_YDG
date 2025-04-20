using System.ComponentModel.DataAnnotations;

namespace PRT.CrwAPI.DTOs
{
    public class ImagenProductoDTO
    {
        public int Id { get; set; }

        [Required]
        public string UrlImagen { get; set; }

        public int ProductoId { get; set; }
    }
}
