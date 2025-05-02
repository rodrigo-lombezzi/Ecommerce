using Ecommerce.Objects.Enums;

namespace Ecommerce.Objetcs.DTOs.Entities
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public double Valor { get; set; }
        public double ValorTotal { get; set; }
        public StatusPedido StatusPedido { get; set; }
    }
}
