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
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadClienteDto>> CreateAsync(CreateClienteDto createClienteDto)
        {
            var cliente = await _repository.CreateAsync(_mapper.Map<Cliente>(createClienteDto));

            return Result.Ok(_mapper.Map<ReadClienteDto>(cliente));
        }

        public async Task<Result> DeleteAsync(long id)
        {
            if (!await _repository.AnyByIdAsync(id))
            {
                return Result.Fail("Cliente não encontrado.");
            }

            await _repository.DeleteAsync(id);

            return Result.Ok();
        }

        public async Task<Result<List<ReadClienteDto>>> FindAllAsync()
        {
            var clientes = await _repository.FindAllAsync();

            if (!clientes.Any())
            {
                return Result.Fail("");
            }

            return Result.Ok(_mapper.Map<List<ReadClienteDto>>(clientes));
        }

        public async Task<Result<ReadClienteDto>> FindByIdAsync(long id)
        {
            if (await _repository.AnyByIdAsync(id))
            {
                var cliente = await _repository.FindByIdAsync(id);

                return Result.Ok(_mapper.Map<ReadClienteDto>(cliente));
            }

            return Result.Fail("Cliente não existe");
        }

        public async Task<Result> UpdateAsync(UpdateClienteDto updateClienteDto)
        {
            if (await _repository.AnyByIdAsync(updateClienteDto.Id))
            {
                var cliente = _mapper.Map<Cliente>(updateClienteDto);

                await _repository.UpdateAsync(cliente);

                return Result.Ok();
            }

            return Result.Fail("Cliente não existe.");
        }
    }
}
