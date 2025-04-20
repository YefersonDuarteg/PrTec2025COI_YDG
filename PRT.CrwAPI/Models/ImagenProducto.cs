using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PRT.CrwAPI.Models
{
    public class ImagenProducto
    {
        public int Id { get; set; }

        [Required]
        public string UrlImagen { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        [JsonIgnore]
        public Producto Producto { get; set; }
    }
}
