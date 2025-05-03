using Ecommerce.Objects.Enums;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Objetcs.DTOs.Entities
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public double Valor { get; set; }
        public double ValorTotal { get; set; }

        public TipoFrete TipoFrete { get; set; }
        public StatusPedido StatusPedido { get; set; } 
    }
}
