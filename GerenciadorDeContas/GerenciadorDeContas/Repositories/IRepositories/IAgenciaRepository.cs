using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Repositories.IRepositories
{
    public interface IAgenciaRepository
    {
        Task<List<Agencia>> FindAllAsync();
        Task<Agencia> FindByIdAsync(long id);
        Task<Agencia> CreateAsync(Agencia agencia);
        Task UpdateAsync(Agencia agencia);
        Task DeleteAsync(long id);
        Task<bool> AnyByIdAsync(long id);
    }
}
