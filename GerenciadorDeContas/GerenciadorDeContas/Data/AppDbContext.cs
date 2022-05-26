using GerenciadorDeContas.ContasBancarias.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeContas.ContasBancarias.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Agencia>()
                   .HasOne(agencia => agencia.Endereco)
                   .WithOne(endereco => endereco.Agencia)
                   .HasForeignKey<Agencia>(agencia => agencia.EnderecoId);

            builder.Entity<Cliente>()
                   .HasMany(cliente => cliente.Contas)
                   .WithOne(conta => conta.Cliente)
                   .HasForeignKey(conta => conta.ClienteId);

            builder.Entity<Conta>()
                   .HasOne(conta => conta.Agencia)
                   .WithMany(agencia => agencia.Contas)
                   .HasForeignKey(conta => conta.AgenciaId);
        }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
