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
        public async Task<IActionResult> Update([FromBody] UpdateContaDto updateContaDto)
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

        [HttpGet("saldo/{accountNumber}")]
        public async Task<IActionResult> GetBalance(int accountNumber)
        {
            var result = await _contaService.GetBalanceByAccountNumberAsync(accountNumber);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.FirstOrDefault());
            }

            return Ok(result.Value);
        }


        [HttpPost("deposito")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest depositRequest)
        {
            var result = await _contaService.DepositAsync(depositRequest);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost("saque")]
        public async Task<IActionResult> WithDraw([FromBody] WithDrawRequest withDrawRequest)
        {
            var result = await _contaService.WithDrawAsync(withDrawRequest);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Value);
        }
    }
}
