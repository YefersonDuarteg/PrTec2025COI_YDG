using Microsoft.EntityFrameworkCore;
using PRT.CrwAPI.Models;


namespace PRT.CrwAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(10, 2);
        }
        public DbSet<ImagenProducto> ImagenesProducto { get; set; }

    }
}
