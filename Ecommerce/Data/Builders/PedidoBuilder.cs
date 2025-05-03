using Ecommerce.Objetcs.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Builders
{
    public class PedidoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);

            modelBuilder.Entity<Pedido>().Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.ValorTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.StatusPedido)
                .HasConversion<string>() 
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
