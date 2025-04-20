using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRT.CrwAPI.DTOs;
using PRT.CrwAPI.Models;
using PRT.CrwAPI.Repositories.Interfaces;

namespace APIProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagenesController : ControllerBase
    {
        private readonly IImagenProductoRepository _repository;

        public ImagenesController(IImagenProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("producto/{productoId}")]
        public async Task<ActionResult<IEnumerable<ImagenProducto>>> GetByProducto(int productoId)
        {
            var imagenes = await _repository.GetByProductoIdAsync(productoId);
            return Ok(imagenes);
        }

        [HttpPost]
        public async Task<ActionResult<ImagenProductoDTO>> Create(ImagenProductoDTO imagen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ImagenPro = new ImagenProducto
            {
                UrlImagen = imagen.UrlImagen,
                ProductoId = imagen.ProductoId
            };

            var created = await _repository.AddAsync(ImagenPro);
            return CreatedAtAction(nameof(GetByProducto), new { productoId = created.ProductoId }, created);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
