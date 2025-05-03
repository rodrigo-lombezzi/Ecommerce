using Ecommerce.Objects.Enums;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services.Strategy.PedidosStrategy
{
    public abstract class PedidoStrategy
    {
        public double valor { get; set; }

        public TipoFrete tipoEntrega { get; set; }

        public IFrete tipoFrete { get; set; }

        public double calculaFrete()
        {
            return tipoFrete.calcula(this.valor);
        }
    }
}
