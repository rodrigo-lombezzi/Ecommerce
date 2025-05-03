using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.Models;

namespace Ecommerce.Services.State
{
    public class CanceladoState : PedidoState
    {
        private Pedido pedido;
        public CanceladoState(Pedido pedido)
        {
            this.pedido = pedido;
        }
        void PedidoState.CancelarPedido()
        {
            throw new Exception("Operação não suportada, pedido foi cancelado");
        }
        void PedidoState.DespacharPedido()
        {
            throw new Exception("Operação não suportada, pedido foi cancelado");
        }
        void PedidoState.SucessoAoPagar()
        {
            throw new Exception("Operação não suportada, pedido foi cancelado");
        }
    }
}
