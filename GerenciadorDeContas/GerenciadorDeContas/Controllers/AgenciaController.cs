using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeContas.ContasBancarias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgenciaController : ControllerBase
    {
        private IAgenciaService _agenciaService;

        public AgenciaController(IAgenciaService agenciaService)
        {
            _agenciaService = agenciaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _agenciaService.FindAllAsync();

            if (result.IsFailed)
            {
                return NoContent();
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _agenciaService.FindByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAgenciaDto createAgenciaDto)
        {
            var result = await _agenciaService.CreateAsync(createAgenciaDto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(Get), new { Id = result.Value.Id}, result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAgenciaDto updateAgenciaDto)
        {
            var result = await _agenciaService.UpdateAsync(updateAgenciaDto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _agenciaService.DeleteAsync(id);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}
