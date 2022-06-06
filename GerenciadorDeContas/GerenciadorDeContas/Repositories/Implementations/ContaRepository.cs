using GerenciadorDeContas.ContasBancarias.Data;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeContas.ContasBancarias.Repositories.Implementations
{
    public class ContaRepository : IContaRepository
    {
        private AppDbContext _context;

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyByIdAsync(long id)
        {
            return await _context.Contas.AnyAsync(x => x.Id == id);
        }

        public async Task<Conta> CreateAsync(Conta conta)
        {
            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();

            return conta;
        }

        public async Task DeleteAsync(long id)
        {
            _context.Contas.Remove(await FindByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Conta>> FindAllAsync()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Conta> FindByIdAsync(long id)
        {
            return await _context.Contas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Conta conta)
        {
            _context.Contas.Update(conta);
            await _context.SaveChangesAsync();
        }
    }
}
