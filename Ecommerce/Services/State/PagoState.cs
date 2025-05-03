using Ecommerce.domains.state;
using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.Models;

namespace Ecommerce.Services.State
{
    public class PagoState : PedidoState
    {
        private Pedido pedido;
        public PagoState(Pedido pedido)
        {
            this.pedido = pedido;
        }

        void PedidoState.SucessoAoPagar()
        {
            throw new InvalidOperationException("O pedido já está pago.");
        }

        void PedidoState.CancelarPedido()
        {
            pedido.StatusPedido = StatusPedido.cancelado;
        }
        void PedidoState.DespacharPedido()
        {
            pedido.StatusPedido = StatusPedido.enviado;
        }
    }
}
