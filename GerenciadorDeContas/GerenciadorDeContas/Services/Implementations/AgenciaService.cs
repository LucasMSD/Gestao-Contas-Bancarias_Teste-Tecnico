using AutoMapper;
using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using GerenciadorDeContas.ContasBancarias.Services.IServices;

namespace GerenciadorDeContas.ContasBancarias.Services.Implementations
{
    public class AgenciaService : IAgenciaService
    {
        private IMapper _mapper;
        private IAgenciaRepository _agenciaRepository;
        private IEnderecoRepository _enderecoRepository;

        public AgenciaService(IMapper mapper, IAgenciaRepository agenciaRepository, IEnderecoRepository enderecoRepository)
        {
            _mapper = mapper;
            _agenciaRepository = agenciaRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Result<ReadAgenciaDto>> CreateAsync(CreateAgenciaDto createAgenciaDto)
        {
            if (!await _enderecoRepository.AnyByIdAsync(createAgenciaDto.EnderecoId))
            {
                return Result.Fail("Endereço da agência não existe.");
            }

            var agencia = await _agenciaRepository.CreateAsync(_mapper.Map<Agencia>(createAgenciaDto));

            return Result.Ok(_mapper.Map<ReadAgenciaDto>(agencia));
        }

        public async Task<Result> DeleteAsync(long id)
        {
            if (!await _agenciaRepository.AnyByIdAsync(id))
            {
                return Result.Fail("Agência não existe.");
            }

            await _agenciaRepository.DeleteAsync(id);

            return Result.Ok();
        }

        public async Task<Result<List<ReadAgenciaDto>>> FindAllAsync()
        {
            var agencias = await _agenciaRepository.FindAllAsync();

            if (!agencias.Any())
            {
                return Result.Fail("");
            }

            return Result.Ok(_mapper.Map<List<ReadAgenciaDto>>(agencias));
        }

        public async Task<Result<ReadAgenciaDto>> FindByIdAsync(long id)
        {
            if (!await _agenciaRepository.AnyByIdAsync(id))
            {
                return Result.Fail("Agência não existe.");
            }

            var agencia = await _agenciaRepository.FindByIdAsync(id);

            return Result.Ok(_mapper.Map<ReadAgenciaDto>(agencia));
        }

        public async Task<Result> UpdateAsync(UpdateAgenciaDto updateAgenciaDto)
        {
            if (!await _agenciaRepository.AnyByIdAsync(updateAgenciaDto.Id))
            {
                return Result.Fail("Agência não existe");
            }

            if (!await _enderecoRepository.AnyByIdAsync(updateAgenciaDto.EnderecoId))
            {
                return Result.Fail("Endereço da agência não existe.");
            }

            await _agenciaRepository.UpdateAsync(_mapper.Map<Agencia>(updateAgenciaDto));

            return Result.Ok();
        }
    }
}
