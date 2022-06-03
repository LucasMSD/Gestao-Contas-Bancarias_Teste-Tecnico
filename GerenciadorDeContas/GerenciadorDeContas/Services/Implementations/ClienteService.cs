using AutoMapper;
using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using GerenciadorDeContas.ContasBancarias.Services.IServices;

namespace GerenciadorDeContas.ContasBancarias.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<Result<ReadClienteDto>> CreateAsync(CreateClienteDto createClienteDto)
        {
            var cliente = await _clienteRepository.CreateAsync(_mapper.Map<Cliente>(createClienteDto));

            return Result.Ok(_mapper.Map<ReadClienteDto>(cliente));
        }

        public async Task<Result> DeleteAsync(long id)
        {
            if (!await _clienteRepository.AnyByIdAsync(id))
            {
                return Result.Fail("Cliente não encontrado.");
            }

            await _clienteRepository.DeleteAsync(id);

            return Result.Ok();
        }

        public async Task<Result<List<ReadClienteDto>>> FindAllAsync()
        {
            var clientes = await _clienteRepository.FindAllAsync();

            if (!clientes.Any())
            {
                return Result.Fail("");
            }

            return Result.Ok(_mapper.Map<List<ReadClienteDto>>(clientes));
        }

        public async Task<Result<ReadClienteDto>> FindByIdAsync(long id)
        {
            if (!await _clienteRepository.AnyByIdAsync(id))
            {
                return Result.Fail("Cliente Não existe");
            }

            return Result.Ok(_mapper.Map<ReadClienteDto>(await _clienteRepository.FindByIdAsync(id)));
        }

        public async Task<Result> UpdateAsync(UpdateClienteDto updateClienteDto)
        {
            if (!await _clienteRepository.AnyByIdAsync(updateClienteDto.Id))
            {
                return Result.Fail("Cliente não existe.");
            }

            await _clienteRepository.UpdateAsync(_mapper.Map<Cliente>(updateClienteDto));

            return Result.Ok();
        }
    }
}
