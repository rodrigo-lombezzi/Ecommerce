using Microsoft.AspNetCore.Mvc;
using Ecommerce.Objetcs.DTOs.Entities;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> GetAll()
        {
            var pedidos = await _pedidoService.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> GetById(int id)
        {
            var pedido = await _pedidoService.GetById(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> Create([FromBody] PedidoDTO pedidoDTO)
        {
            await _pedidoService.Create(pedidoDTO);
            return CreatedAtAction(nameof(GetById), new { id = pedidoDTO.Id }, pedidoDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PedidoDTO pedidoDTO)
        {
            if (id != pedidoDTO.Id)
                return BadRequest("Id do pedido não corresponde ao DTO.");

            await _pedidoService.Update(pedidoDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedidoDTO = await _pedidoService.GetById(id);
            if (pedidoDTO == null)
                return NotFound();

            await _pedidoService.Remove(pedidoDTO);
            return NoContent();
        }
    }
}
