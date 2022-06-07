using AutoMapper;
using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
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

        public Task<Result> Deposit(CreateMovimentacaoDto createMovimentacaoDto)
        {
            throw new NotImplementedException();
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
    }
}
