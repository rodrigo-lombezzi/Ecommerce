using AutoMapper;
using Ecommerce.Objetcs.DTOs.Entities;
using Ecommerce.Objetcs.Models;
using Ecommerce.Repositories.Interfaces;

namespace Ecommerce.Services.Entities
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoDTO>> GetAll()
        {
            var pedidos = await _pedidoRepository.GetAll();
            return _mapper.Map<IEnumerable<PedidoDTO>>(pedidos);
        }

        public async Task<PedidoDTO> GetById(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);
            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task Create(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            await _pedidoRepository.Create(pedido);
            pedidoDTO.Id = pedido.Id;
        }

        public async Task Update(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            await _pedidoRepository.Update(pedido);
        }

        public async Task Remove(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            await _pedidoRepository.Remove(pedido);
        }
    }
}
