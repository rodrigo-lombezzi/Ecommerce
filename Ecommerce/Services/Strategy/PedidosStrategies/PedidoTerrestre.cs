using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.Models;

namespace Ecommerce.Services.Strategy.PedidosStrategy 
{
    public class PedidoTerrestre : PedidoStrategy
    {
        public PedidoTerrestre()
        {
            tipoEntrega = TipoFrete.terrestre;
        }
    }
}
