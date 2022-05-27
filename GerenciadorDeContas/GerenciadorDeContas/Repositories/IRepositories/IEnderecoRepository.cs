using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Repositories.IRepositories
{
    public interface IEnderecoRepository
    {
        Task<List<Endereco>> FindAllAsync();
        Task<Endereco> FindByIdAsync(long id);
        Task<Endereco> CreateAsync(Endereco endereco);
        Task UpdateAsync(Endereco endereco);
        Task DeleteAsync(long id);
        Task<bool> AnyByIdAsync(long id);
    }
}
