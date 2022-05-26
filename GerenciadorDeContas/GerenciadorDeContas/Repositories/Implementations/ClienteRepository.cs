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
        private readonly IMapper _mapper;

        public ClienteRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            var cliente = await _context.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();

            return cliente;
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            var clienteBanco = await _context.Clientes.Where(x => x.Id == cliente.Id).FirstOrDefaultAsync();

            _mapper.Map(cliente, clienteBanco);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistCliente(long id)
        {
            return await _context.Clientes.AnyAsync(x => x.Id == id);
        }
    }
}
