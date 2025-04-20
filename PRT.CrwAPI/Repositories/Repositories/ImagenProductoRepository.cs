using PRT.CrwAPI.Data;
using PRT.CrwAPI.Models;
using PRT.CrwAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PRT.CrwAPI.Repositories.Repositories
{
    public class ImagenProductoRepository : IImagenProductoRepository
    {
        private readonly AppDbContext _context;

        public ImagenProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImagenProducto>> GetByProductoIdAsync(int productoId)
        {
            return await _context.ImagenesProducto
                                 .Where(i => i.ProductoId == productoId)
                                 .ToListAsync();
        }

        public async Task<ImagenProducto> AddAsync(ImagenProducto imagen)
        {
            _context.ImagenesProducto.Add(imagen);
            await _context.SaveChangesAsync();
            return imagen;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var imagen = await _context.ImagenesProducto.FindAsync(id);
            if (imagen == null) return false;

            _context.ImagenesProducto.Remove(imagen);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
