using Microsoft.AspNetCore.Mvc;
using PRT.CrwAPI.Models;
using Microsoft.EntityFrameworkCore;
using PRT.CrwAPI.Repositories.Interfaces;
using PRT.CrwAPI.DTOs;

namespace PRT.CrwAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repository;

        public ProductosController(IProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetAll()
        {
            var productos = await _repository.GetAllAsync();

            var productosDto = productos.Select(producto => new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Estado = producto.Estado,
                Imagenes = producto.Imagenes?.Select(imagen => new ImagenProductoDTO
                {
                    Id = imagen.Id,
                    UrlImagen = imagen.UrlImagen,
                    ProductoId = imagen.ProductoId
                }).ToList() ?? new List<ImagenProductoDTO>()
            });

            return Ok(productosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            if (producto == null) return NotFound();

            List<ImagenProductoDTO> tempObj = new List<ImagenProductoDTO>();
            if (producto.Imagenes != null)
            {
                tempObj = producto.Imagenes?.Select(i => new ImagenProductoDTO
                {
                    Id = i.Id,
                    UrlImagen = i.UrlImagen,
                    ProductoId = i.ProductoId
                }).ToList();
            }

            var productoDto = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Estado = producto.Estado,
                Imagenes = tempObj
            };

            return Ok(productoDto);
        }

        [HttpGet("ordenado/precio")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetOrderedByPrice()
        {
            var productos = await _repository.GetOrderedByPriceAsync();

            var productosDto = productos.Select(producto => new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Estado = producto.Estado,
                Imagenes = producto.Imagenes?.Select(imagen => new ImagenProductoDTO
                {
                    Id = imagen.Id,
                    UrlImagen = imagen.UrlImagen,
                    ProductoId = imagen.ProductoId
                }).ToList() ?? new List<ImagenProductoDTO>()
            });

            return Ok(productosDto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Create(ProductoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Estado = dto.Estado,
                FechaCreacion = DateTime.Now
            };

            var created = await _repository.AddAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest("ID mismatch");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _repository.UpdateAsync(producto);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
