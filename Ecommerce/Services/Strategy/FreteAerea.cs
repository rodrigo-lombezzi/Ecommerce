using Ecommerce.Objects.Enums;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services.Strategy
{
    public class FreteAerea : IFrete
    {
        public TipoFrete Tipo => TipoFrete.aerea;
        public double calcula(double valor)
        {
            return valor * 0.1;
        }
    }
}
