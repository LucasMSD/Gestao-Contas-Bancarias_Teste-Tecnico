using GerenciadorDeContas.ContasBancarias.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Models
{
    public class Movimentacao
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public long ContaDestinoId { get; set; }
        [Required]
        public long ContaDestinoNumero { get; set; }
        public virtual Conta ContaDestino { get; set; }
        [Required]
        public long ContaOrigemId { get; set; }
        [Required]
        public long ContaOrigemNumero { get; set; }
        public virtual Conta ContaOrigem { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        [Required]
        public DateTime Horario { get; set; }
    }
}
