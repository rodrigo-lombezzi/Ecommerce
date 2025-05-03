using AutoMapper;
using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.DTOs.Entities;
using Ecommerce.Objetcs.Models;
using Ecommerce.Repositories.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services.Entities
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IFrete> _fretes;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper, IEnumerable<IFrete> fretes)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _fretes = fretes;
        }

        public double CalculaFrete(double valor, TipoFrete tipoFrete)
        {
            var strategy = _fretes.Single(f => f.Tipo == tipoFrete);
            return strategy.calcula(valor);
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
            pedidoDTO.ValorTotal = pedidoDTO.Valor + CalculaFrete(pedidoDTO.Valor, pedidoDTO.TipoFrete);

            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            await _pedidoRepository.Create(pedido);
            pedidoDTO.Id = pedido.Id;
        }

        public async Task Update(PedidoDTO pedidoDTO)
        {
            pedidoDTO.ValorTotal = pedidoDTO.Valor + CalculaFrete(pedidoDTO.Valor, pedidoDTO.TipoFrete);
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
