using Ecommerce.Data.Builders;
using Ecommerce.Objetcs.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Pedido> Pedidos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            PedidoBuilder.Build(modelBuilder);
        }
    }
}