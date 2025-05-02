using Ecommerce.Objetcs.Models;

namespace Ecommerce.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<Pedido> Create(Pedido pedido);
        Task<Pedido> Update(Pedido pedido);
        Task<Pedido> Remove(Pedido pedido);
    }
}
