using GerenciadorDeContas.ContasBancarias.Data;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeContas.ContasBancarias.Repositories.Implementations
{
    public class AgenciaRepository : IAgenciaRepository
    {
        private AppDbContext _context;

        public AgenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyByIdAsync(long id)
        {
            return await _context.Agencias.AnyAsync(x => x.Id == id);
        }

        public async Task<Agencia> CreateAsync(Agencia agencia)
        {
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();

            return agencia;
        }

        public async Task DeleteAsync(long id)
        {
            _context.Agencias.Remove(await FindByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Agencia>> FindAllAsync()
        {
            return await _context.Agencias.ToListAsync();
        }

        public async Task<Agencia> FindByIdAsync(long id)
        {
            return await _context.Agencias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Agencia agencia)
        {
            _context.Agencias.Update(agencia);
            await _context.SaveChangesAsync();
        }
    }
}
