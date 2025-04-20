using PRT.CrwAPI.Models;

namespace PRT.CrwAPI.Repositories.Interfaces
{
    public interface IImagenProductoRepository
    {
        Task<IEnumerable<ImagenProducto>> GetByProductoIdAsync(int productoId);
        Task<ImagenProducto> AddAsync(ImagenProducto imagen);
        Task<bool> DeleteAsync(int id);
    }
}
