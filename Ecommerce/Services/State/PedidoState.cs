using Ecommerce.Objetcs.Models;

namespace Ecommerce.Services.State
{
    public interface PedidoState
    {
        void SucessoAoPagar();
        void CancelarPedido();
        void DespacharPedido();
    }
}
