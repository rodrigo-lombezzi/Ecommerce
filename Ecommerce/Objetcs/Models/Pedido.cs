using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Numerics;
using System.Xml.Linq;
using Ecommerce.Objects.Enums;

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
        [Column("TipoFrete")]
        public string TipoFrete { get; set; }

        [Column("StatusPedido")]
        public StatusPedido StatusPedido { get; set; }

        public Pedido() { }

        public Pedido(int id, string nome, double valor, double valortotal, string tipofrete, StatusPedido statusPedido)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            ValorTotal = valortotal;
            TipoFrete = tipofrete;
            StatusPedido = statusPedido;
        }
    }
}
