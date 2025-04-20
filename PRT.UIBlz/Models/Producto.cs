namespace PRT.UIBlz.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; } = true;

        public List<ImagenProducto>? Imagenes { get; set; } = new List<ImagenProducto>();
    }
}
