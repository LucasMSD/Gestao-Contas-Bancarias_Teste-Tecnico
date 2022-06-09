using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Repositories.IRepositories
{
    public interface IContaRepository
    {
        Task<List<Conta>> FindAllAsync();
        Task<Conta> FindByIdAsync(long id);
        Task<Conta> FindByNumberAsync(long accountNumber);
        Task<Conta> CreateAsync(Conta conta);
        Task UpdateAsync(Conta conta);
        Task DeleteAsync(long id);
        Task<bool> AnyByIdAsync(long id);
        Task<decimal> DepositAsync(Movimentacao movimentacao);
        Task<decimal> GetBalanceByIdAsync(long contaId);
        Task<decimal> GetBalanceByNumberAsync(long contaId);
        Task<bool> AnyByNumberAsync(long accoutNumber);
        Task<List<Movimentacao>> GetMovimentacaosByAccountNumberAsync(long accountNumber);
        Task<List<Movimentacao>> GetMovimentacaosByAccountIdAsync(long accountId);
        Task<decimal> WithDrawAsync(Movimentacao movimentacao);
        Task<decimal> TransferAsync(Movimentacao movimentacao);
    }
}
