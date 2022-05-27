using AutoMapper;
using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using GerenciadorDeContas.ContasBancarias.Services.IServices;

namespace GerenciadorDeContas.ContasBancarias.Services.Implementations
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadEnderecoDto>> CreateAsync(CreateEnderecoDto createEnderecoDto)
        {
            var endereco = await _repository.CreateAsync(_mapper.Map<Endereco>(createEnderecoDto));

            return Result.Ok(_mapper.Map<ReadEnderecoDto>(endereco));
        }

        public async Task<Result> DeleteAsync(long id)
        {
            if (await _repository.AnyByIdAsync(id))
            {
                await _repository.DeleteAsync(id);

                return Result.Ok();
            }

            return Result.Fail("Endereco não existe");
        }

        public async Task<Result<List<ReadEnderecoDto>>> FindAllAsync()
        {
            var enderecos = await _repository.FindAllAsync();

            if (!enderecos.Any())
            {
                return Result.Fail("");
            }

            return Result.Ok(_mapper.Map<List<ReadEnderecoDto>>(enderecos));
        }

        public async Task<Result<ReadEnderecoDto>> FindByIdAsync(long id)
        {
            if (await _repository.AnyByIdAsync(id))
            {
                return Result.Ok(_mapper.Map<ReadEnderecoDto>(await _repository.FindByIdAsync(id)));
            }

            return Result.Fail("Endereco não existe.");
        }

        public async Task<Result> UpdateAsync(UpdateEnderecoDto updateEnderecoDto)
        {
            if (await _repository.AnyByIdAsync(updateEnderecoDto.Id))
            {
                await _repository.UpdateAsync(_mapper.Map<Endereco>(updateEnderecoDto));

                return Result.Ok();
            }

            return Result.Fail("Endereco não existe");
        }
    }
}
