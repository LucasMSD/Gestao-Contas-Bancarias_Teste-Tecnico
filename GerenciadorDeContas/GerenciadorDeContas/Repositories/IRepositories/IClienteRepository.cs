using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Repositories.IRepositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> FindAllAsync();
        Task<Cliente> FindByIdAsync(long id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(long id);
        Task<bool> AnyByIdAsync(long id);
    }
}
