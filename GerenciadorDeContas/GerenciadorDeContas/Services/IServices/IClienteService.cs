using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;

namespace GerenciadorDeContas.ContasBancarias.Services.IServices
{
    public interface IClienteService
    {
        Task<Result<List<ReadClienteDto>>> FindAllAsync();
        Task<Result<ReadClienteDto>> FindByIdAsync(long id);
        Task<Result<ReadClienteDto>> CreateAsync(CreateClienteDto createClienteDto);
        Task<Result> UpdateAsync(UpdateClienteDto updateClienteDto);
        Task<Result> DeleteAsync(long id);
    }
}
