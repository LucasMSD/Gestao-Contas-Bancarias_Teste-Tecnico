using AutoMapper;
using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Enums;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using GerenciadorDeContas.ContasBancarias.Services.IServices;

namespace GerenciadorDeContas.ContasBancarias.Services.Implementations
{
    public class ContaService : IContaService
    {
        private IMapper _mapper;
        private IContaRepository _contaRepository;
        private IAgenciaRepository _agenciaRepository;
        private IClienteRepository _clienteRepository;

        public ContaService(IMapper mapper, IContaRepository contaRepository, IAgenciaRepository agenciaRepository, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
            _agenciaRepository = agenciaRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<Result<ReadContaDto>> CreateAsync(CreateContaDto createContaDto)
        {
            if (!await _agenciaRepository.AnyByIdAsync(createContaDto.AgenciaId))
            {
                return Result.Fail("Agência não existe.");
            }

            if (!await _clienteRepository.AnyByIdAsync(createContaDto.ClienteId))
            {
                return Result.Fail("Cliente não existe.");
            }

            var conta = await _contaRepository.CreateAsync(_mapper.Map<Conta>(createContaDto));

            return Result.Ok(_mapper.Map<ReadContaDto>(conta));
        }

        public async Task<Result> DeleteAsync(long id)
        {
            if (!await _contaRepository.AnyByIdAsync(id))
            {
                return Result.Fail("Conta não existe.");
            }

            await _contaRepository.DeleteAsync(id);

            return Result.Ok();
        }

        public async Task<Result<DepositResponse>> DepositAsync(DepositRequest depositRequest)
        {
            var result = new Result();

            var saldoAnterior = await _contaRepository.GetBalanceByNumberAsync(depositRequest.ContaDestinoNumero);

            if (!await _contaRepository.AnyByNumberAsync(depositRequest.ContaDestinoNumero))
            {
                result.WithError("Conta para depósito não existe");
            }

            if (depositRequest.Valor <= 0)
            {
                result.WithError("Valor de depósito não pode ser menor ou igual a zero.");
            }

            if (result.HasError<IError>())
            {
                return result;
            }

            var movimentacao = _mapper.Map<Movimentacao>(depositRequest);

            var contaDestino = await _contaRepository.FindByNumberAsync(depositRequest.ContaDestinoNumero);

            movimentacao.ContaDestinoId = contaDestino.Id;
            movimentacao.TipoMovimentacao = TipoMovimentacao.Deposito;
            movimentacao.Horario = DateTime.Now;

            var saldoAtual = await _contaRepository.DepositAsync(movimentacao);

            return Result.Ok(new DepositResponse
            {
                Numero = depositRequest.ContaDestinoNumero,
                SaldoAnterior = saldoAnterior,
                SaldoAtual = saldoAtual
            });
        }

        public async Task<Result<List<ReadContaDto>>> FindAllAsync()
        {
            var contas = await _contaRepository.FindAllAsync();

            if (!contas.Any())
            {
                return Result.Fail("");
            }

            return Result.Ok(_mapper.Map<List<ReadContaDto>>(contas));
        }

        public async Task<Result<ReadContaDto>> FindByIdAsync(long id)
        {
            if (!await _contaRepository.AnyByIdAsync(id))
            {
                return Result.Fail("");
            }

            return Result.Ok(_mapper.Map<ReadContaDto>(await _contaRepository.FindByIdAsync(id)));
        }

        public async Task<Result<decimal>> GetBalanceByAccountNumberAsync(int accountNumber)
        {
            if (!await _contaRepository.AnyByNumberAsync(accountNumber))
            {
                return Result.Fail("Conta não existe");
            }

            return Result.Ok(await _contaRepository.GetBalanceByNumberAsync(accountNumber));
        }

        public async Task<Result<TransferResponse>> TrasnferAsync(TransferRequest transferRequest)
        {
            var result = new Result();
            var saldoAnterior = await _contaRepository.GetBalanceByNumberAsync(transferRequest.ContaOrigemNumero);

            if (!await _contaRepository.AnyByNumberAsync(transferRequest.ContaOrigemNumero))
            {
                result.WithError("Conta de origem não existe.");
            }

            if (!await _contaRepository.AnyByNumberAsync(transferRequest.ContaDestinoNumero))
            {
                result.WithError("Conta de destino não existe.");
            }

            if (transferRequest.Valor <= 0)
            {
                result.WithError("Valor para transferência não pode ser menor ou igual a zero.");
            }

            if (transferRequest.Valor > saldoAnterior)
            {
                result.WithError("Valor para tranferência é maior do que o saldo disponível.");
            }

            if (result.HasError<IError>())
            {
                return result;
            }

            var movimentacao = _mapper.Map<Movimentacao>(transferRequest);

            var contaOrigem = await _contaRepository.FindByNumberAsync((long)movimentacao.ContaOrigemNumero);
            var contaDestino = await _contaRepository.FindByNumberAsync((long)movimentacao.ContaDestinoNumero);

            movimentacao.ContaOrigemId = contaOrigem.Id;
            movimentacao.ContaDestinoId = contaDestino.Id;
            movimentacao.TipoMovimentacao = TipoMovimentacao.Transacao;
            movimentacao.Horario = DateTime.Now;

            var saldoAtual = await _contaRepository.TransferAsync(movimentacao);

            return Result.Ok(new TransferResponse
            {
                Numero = contaOrigem.Numero,
                SaldoAnterior = saldoAnterior,
                SaldoAtual = saldoAtual,
            });
        }

        public async Task<Result> UpdateAsync(UpdateContaDto updateContaDto)
        {
            if (!await _contaRepository.AnyByIdAsync(updateContaDto.Id))
            {
                return Result.Fail("Conta não existe.");
            }

            if (!await _agenciaRepository.AnyByIdAsync(updateContaDto.AgenciaId))
            {
                return Result.Fail("Agência não existe.");
            }

            if (!await _clienteRepository.AnyByIdAsync(updateContaDto.ClienteId))
            {
                return Result.Fail("Cliente não existe.");
            }

            await _contaRepository.UpdateAsync(_mapper.Map<Conta>(updateContaDto));

            return Result.Ok();
        }

        public async Task<Result<WithDrawResponse>> WithDrawAsync(WithDrawRequest withDrawRequest)
        {
            var result = new Result();

            var saldoAnterior = await _contaRepository.GetBalanceByNumberAsync(withDrawRequest.ContaOrigemNumero);

            if (!await _contaRepository.AnyByNumberAsync(withDrawRequest.ContaOrigemNumero))
            {
                result.WithError("Conta não existe.");
            }

            if (withDrawRequest.Valor <= 0)
            {
                result.WithError("O valor de saque não pode ser menor ou igual a zero.");
            }

            if (withDrawRequest.Valor > saldoAnterior)
            {
                result.WithError("Não há saldo suficiente para realizar o saque.");
            }

            if (result.HasError<IError>())
            {
                return result;
            }

            var movimentacao = _mapper.Map<Movimentacao>(withDrawRequest);
            var contaOrigem = await _contaRepository.FindByNumberAsync(withDrawRequest.ContaOrigemNumero);

            movimentacao.ContaOrigemId = contaOrigem.Id;
            movimentacao.TipoMovimentacao = TipoMovimentacao.Saque;
            movimentacao.Horario = DateTime.Now;

            var saldoAtual = await _contaRepository.WithDrawAsync(movimentacao);

            return Result.Ok(new WithDrawResponse
            {
                Numero = contaOrigem.Numero,
                SaldoAnterior = saldoAnterior,
                SaldoAtual = saldoAtual
            });
        }
    }
}
