using AutoMapper;
using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.DTOs.Entities;
using Ecommerce.Objetcs.Models;
using Ecommerce.Repositories.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.Services.State;

namespace Ecommerce.Services.Entities
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IFrete> _fretes;
        public PedidoState estadoAtual { get; set; }
        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper, IEnumerable<IFrete> fretes)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _fretes = fretes;
            this.estadoAtual = new AguardandoPagamentoState(this);
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
            pedido.StatusPedido = StatusPedido.aguardando;
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
        public async Task SucessoAoPagar(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);
            if (pedido == null)
                throw new Exception("Pedido não encontrado.");

            if (pedido.StatusPedido != StatusPedido.aguardando)
                throw new Exception("Pedido não está aguardando pagamento.");

            pedido.StatusPedido = StatusPedido.pago;
            await _pedidoRepository.Update(pedido);
        }

        public async Task CancelarPedido(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);
            if (pedido == null)
                throw new Exception("Pedido não encontrado.");

            if (pedido.StatusPedido == StatusPedido.pago || pedido.StatusPedido == StatusPedido.enviado)
                throw new Exception("Não é possível cancelar um pedido já pago ou enviado.");

            pedido.StatusPedido = StatusPedido.cancelado;
            await _pedidoRepository.Update(pedido);
        }
        public async Task DespacharPedido(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);
            if (pedido == null)
                throw new Exception("Pedido não encontrado.");

            if (pedido.StatusPedido != StatusPedido.pago)
                throw new Exception("Apenas pedidos pagos podem ser despachados.");

            pedido.StatusPedido = StatusPedido.enviado;
            await _pedidoRepository.Update(pedido);
        }

    }
}
