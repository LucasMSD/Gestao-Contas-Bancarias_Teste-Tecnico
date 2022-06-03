using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeContas.ContasBancarias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _clienteService.FindAllAsync();

            if (result.IsFailed)
            {
                return NoContent();
            }

            return Ok(result.Value);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _clienteService.FindByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDto createClienteDto)
        {
            var result = await _clienteService.CreateAsync(createClienteDto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            return CreatedAtAction(nameof(Get), new { Id = result.Value.Id }, result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClienteDto updateClienteDto)
        {
            var result = await _clienteService.UpdateAsync(updateClienteDto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _clienteService.DeleteAsync(id);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            return NoContent();
        }
    }
}
