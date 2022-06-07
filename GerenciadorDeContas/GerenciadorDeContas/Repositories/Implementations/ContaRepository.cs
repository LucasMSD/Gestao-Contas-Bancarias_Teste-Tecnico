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

        public async Task<bool> AnyByNumberAsync(long numberAccount)
        {
            return await _context.Contas.AnyAsync(x => x.Numero == numberAccount);
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

        public async Task<decimal> DepositAsync(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();

            return await GetBalanceByIdAsync((long)movimentacao.ContaDestinoId);
        }

        public async Task<List<Conta>> FindAllAsync()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Conta> FindByIdAsync(long id)
        {
            return await _context.Contas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Conta> FindByNumberAsync(long numberAccount)
        {
            return await _context.Contas.FirstOrDefaultAsync(x => x.Numero == numberAccount);
        }

        public async Task<decimal> GetBalanceByIdAsync(long contaId)
        {
            decimal saldo = 0;
            var movimentacoes = await GetMovimentacaosByAccountIdAsync(contaId);

            var movimentacoesEntrada = movimentacoes.Where(x => x.ContaDestinoId.Equals(contaId));
            var movimentacoesSaida = movimentacoes.Where(x => x.ContaOrigemId.Equals(contaId));

            var valorEntrada = movimentacoesEntrada.Sum(x => x.Valor);
            var valorSaida = movimentacoesSaida.Sum(x => x.Valor);

            saldo = valorEntrada - valorSaida;

            return saldo;
        }

        public async Task<decimal> GetBalanceByNumberAsync(long accountNumber)
        {
            decimal saldo = 0;
            var movimentacoes = await GetMovimentacaosByAccountNumberAsync(accountNumber);

            var movimentacoesEntrada = movimentacoes.Where(x => x.ContaDestinoNumero.Equals(accountNumber));
            var movimentacoesSaida = movimentacoes.Where(x => x.ContaOrigemNumero.Equals(accountNumber));

            var valorEntrada = movimentacoesEntrada.Sum(x => x.Valor);
            var valorSaida = movimentacoesSaida.Sum(x => x.Valor);

            saldo = valorEntrada - valorSaida;

            return saldo;
        }

        public async Task<List<Movimentacao>> GetMovimentacaosByAccountNumberAsync(long accountNumber)
        {
            return await (from movimentacao in _context.Movimentacoes
                          where movimentacao.ContaDestinoNumero == accountNumber
                             || movimentacao.ContaOrigemNumero == accountNumber
                          select movimentacao).ToListAsync();
        }

        public async Task<List<Movimentacao>> GetMovimentacaosByAccountIdAsync(long accountId)
        {
            return await (from movimentacao in _context.Movimentacoes
                          where movimentacao.ContaDestinoId == accountId
                             || movimentacao.ContaOrigemId == accountId
                          select movimentacao).ToListAsync();
        }

        public async Task UpdateAsync(Conta conta)
        {
            _context.Contas.Update(conta);
            await _context.SaveChangesAsync();
        }
    }
}
