using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeContas.ContasBancarias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.FindAllAsync();

            if (result.IsSuccess)
            {
                if (result.Value.Count > 0)
                {
                    return Ok(result.Value);
                }

                return NoContent();
            }

            return StatusCode(500);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.FindByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDto createClienteDto)
        {
            var result = await _service.CreateAsync(createClienteDto);

            if (result.IsFailed)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { Id = result.Value.Id }, result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClienteDto updateClienteDto)
        {
            var result = await _service.UpdateAsync(updateClienteDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteAsync(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
