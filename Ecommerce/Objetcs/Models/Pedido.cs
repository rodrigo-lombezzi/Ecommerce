using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Objects.Enums;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Objetcs.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Valor")]
        public double Valor { get; set;}
        [Column("ValorTotal")]
        public double ValorTotal { get; set;}
 
        [Column("StatusPedido")]
        public StatusPedido StatusPedido { get; set; }

        public Pedido() { }

        public Pedido(int id, string nome, double valor, double valortotal, StatusPedido statusPedido)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            ValorTotal = valortotal;
            StatusPedido = statusPedido;
        }
    }
}
