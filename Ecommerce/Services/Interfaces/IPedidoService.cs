using Ecommerce.Objects.Enums;
using Ecommerce.Objetcs.DTOs.Entities;
using Ecommerce.Objetcs.Models;

public interface IPedidoService
{
    Task<IEnumerable<PedidoDTO>> GetAll();
    Task<PedidoDTO> GetById(int id);
    Task Create(PedidoDTO pedido);
    Task Update(PedidoDTO pedido);
    Task Remove(PedidoDTO pedido);
    double CalculaFrete(double valor, TipoFrete tipoFrete);
    Task SucessoAoPagar(int id);
    Task CancelarPedido(int id);
    Task DespacharPedido(int id);

}
