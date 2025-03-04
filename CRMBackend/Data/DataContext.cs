using Microsoft.EntityFrameworkCore;
using CRMControllers.Entidades;
namespace CRMBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<OportunidadVenta> OportunidadVenta { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
