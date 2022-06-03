using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;

namespace GerenciadorDeContas.ContasBancarias.Services.IServices
{
    public interface IAgenciaService
    {
        Task<Result<List<ReadAgenciaDto>>> FindAllAsync();
        Task<Result<ReadAgenciaDto>> FindByIdAsync(long id);
        Task<Result<ReadAgenciaDto>> CreateAsync(CreateAgenciaDto createAgenciaDto);
        Task<Result> UpdateAsync(UpdateAgenciaDto updateAgenciaDto);
        Task<Result> DeleteAsync(long id);
    }
}
