using GerenciadorDeContas.ContasBancarias.Data;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeContas.ContasBancarias.Repositories.Implementations
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> CreateAsync(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        public async Task DeleteAsync(long id)
        {
            var cliente = await FindByIdAsync(id);
            _context.Enderecos.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Endereco>> FindAllAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> FindByIdAsync(long id)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyByIdAsync(long id)
        {
            return await _context.Enderecos.AnyAsync(x => x.Id == id);
        }
    }
}
