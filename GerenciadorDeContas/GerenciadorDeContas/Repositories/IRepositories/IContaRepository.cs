using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Repositories.IRepositories
{
    public interface IContaRepository
    {
        Task<List<Conta>> FindAllAsync();
        Task<Conta> FindByIdAsync(long id);
        Task<Conta> CreateAsync(Conta conta);
        Task UpdateAsync(Conta conta);
        Task DeleteAsync(long id);
        Task<bool> AnyByIdAsync(long id);
    }
}
