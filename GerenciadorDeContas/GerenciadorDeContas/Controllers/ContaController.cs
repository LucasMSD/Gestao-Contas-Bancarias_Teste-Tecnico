using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeContas.ContasBancarias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _contaService.FindAllAsync();

            if (result.IsFailed)
            {
                return NoContent();
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _contaService.FindByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContaDto createContaDto)
        {
            var result = await _contaService.CreateAsync(createContaDto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            return CreatedAtAction(nameof(Get), new { Id = result.Value.Id }, result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContaDto updateContaDto)
        {
            var result = await _contaService.UpdateAsync(updateContaDto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _contaService.DeleteAsync(id);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            return NoContent();
        }
    }
}
