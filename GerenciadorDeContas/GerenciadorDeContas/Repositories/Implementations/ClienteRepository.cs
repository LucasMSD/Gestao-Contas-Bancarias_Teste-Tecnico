using AutoMapper;
using GerenciadorDeContas.ContasBancarias.Data;
using GerenciadorDeContas.ContasBancarias.Models;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeContas.ContasBancarias.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task DeleteAsync(long id)
        {
            _context.Clientes.Remove(await FindByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> FindByIdAsync(long id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyByIdAsync(long id)
        {
            return await _context.Clientes.AnyAsync(x => x.Id == id);
        }
    }
}
