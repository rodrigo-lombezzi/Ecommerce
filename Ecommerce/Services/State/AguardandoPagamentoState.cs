using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.Models;
using Ecommerce.Services.Entities;

namespace Ecommerce.Services.State
{
    public class AguardandoPagamentoState : PedidoState
    {
        private readonly Pedido pedido;
        private PedidoService pedidoService;

        public AguardandoPagamentoState(PedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        void PedidoState.SucessoAoPagar()
        {
            pedido.StatusPedido = StatusPedido.pago;
        }

        void PedidoState.CancelarPedido()
        {
            pedido.StatusPedido = StatusPedido.cancelado;
        }

        void PedidoState.DespacharPedido()
        {
            throw new InvalidOperationException("Não é possível despachar um pedido que ainda não foi pago.");
        }
    }
}
