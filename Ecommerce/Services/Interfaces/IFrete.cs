using Ecommerce.Objects.Enums;

namespace Ecommerce.Services.Interfaces
{
    public interface IFrete
    {
        TipoFrete Tipo { get; }
        public double calcula(double valor);
    }

}