using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;

namespace GerenciadorDeContas.ContasBancarias.Services.IServices
{
    public interface IEnderecoService
    {
        Task<Result<List<ReadEnderecoDto>>> FindAllAsync();
        Task<Result<ReadEnderecoDto>> FindByIdAsync(long id);
        Task<Result<ReadEnderecoDto>> CreateAsync(CreateEnderecoDto createEnderecoDto);
        Task<Result> UpdateAsync(UpdateEnderecoDto updateEnderecoDto);
        Task<Result> DeleteAsync(long id);
    }
}
