﻿using PRT.CrwAPI.Models;

namespace PRT.CrwAPI.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<IEnumerable<Producto>> GetOrderedByPriceAsync();
        Task<Producto> AddAsync(Producto producto);
        Task<Producto?> UpdateAsync(Producto producto);
        Task<bool> DeleteAsync(int id);
    }
}
