using Ecommerce.Objects.Enums;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services.Strategy.Frete
{
    public class FreteTerrestre : IFrete
    {
        public TipoFrete Tipo => TipoFrete.terrestre;
        public double calcula(double valor)
        {
            return valor * 0.05;
        }
    }
}
