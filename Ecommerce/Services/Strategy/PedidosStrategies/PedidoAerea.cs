using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.Models;

namespace Ecommerce.Services.Strategy.PedidosStrategy
{
    public class PedidoAerea : PedidoStrategy
    {
        public PedidoAerea()
        {
            tipoEntrega = TipoFrete.aerea;
        }
    }
}
