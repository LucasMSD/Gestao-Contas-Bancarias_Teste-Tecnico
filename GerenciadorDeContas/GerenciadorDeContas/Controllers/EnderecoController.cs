using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeContas.ContasBancarias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;

        public EnderecoController(IEnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var result = await _service.FindAllAsync();

            if (result.IsFailed)
            {
                return NoContent();
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var result = await _service.FindByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnderecoDto createEnderecoDto)
        {
            var result = await _service.CreateAsync(createEnderecoDto);

            if (result.IsFailed)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(FindById), new { result.Value.Id }, result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEnderecoDto updateEnderecoDto)
        {
            var result = await _service.UpdateAsync(updateEnderecoDto);

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
