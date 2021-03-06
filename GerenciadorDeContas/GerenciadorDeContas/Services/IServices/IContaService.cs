using FluentResults;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;

namespace GerenciadorDeContas.ContasBancarias.Services.IServices
{
    public interface IContaService
    {
        Task<Result<List<ReadContaDto>>> FindAllAsync();
        Task<Result<ReadContaDto>> FindByIdAsync(long id);
        Task<Result<ReadContaDto>> CreateAsync(CreateContaDto createContaDto);
        Task<Result> UpdateAsync(UpdateContaDto updateContaDto);
        Task<Result> DeleteAsync(long id);
        Task<Result<DepositResponse>> DepositAsync(DepositRequest depositRequest);
        Task<Result<decimal>> GetBalanceByAccountNumberAsync(int accountNumber);
        Task<Result<WithDrawResponse>> WithDrawAsync(WithDrawRequest withDrawRequest);
        Task<Result<TransferResponse>> TrasnferAsync(TransferRequest transferRequest);
        Task<Result<List<ExtratoDto>>> GetStatementAsync(int accountNumber);
    }
}
