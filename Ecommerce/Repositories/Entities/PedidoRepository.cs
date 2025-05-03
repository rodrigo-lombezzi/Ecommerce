using Ecommerce.Data;
using Ecommerce.Objetcs.Models;
using Ecommerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories.Entities
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDBContext _dbContext;

        public PedidoRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _dbContext.Pedidos.AsNoTracking().ToListAsync();
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _dbContext.Pedidos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pedido> Create(Pedido pedido)
        {
            _dbContext.Pedidos.Add(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> Update(Pedido pedido)
        {
            _dbContext.Entry(pedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> Remove(Pedido pedido)
        {
            _dbContext.Pedidos.Remove(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }
    }
}
