using GerenciadorDeContas.ContasBancarias.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Models
{
    public class Movimentacao
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public long? ContaDestinoId { get; set; }
        public long? ContaDestinoNumero { get; set; }
        public virtual Conta ContaDestino { get; set; }
        public long? ContaOrigemId { get; set; }
        public long? ContaOrigemNumero { get; set; }
        public virtual Conta ContaOrigem { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        [EnumDataType(typeof(TipoMovimentacao))]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        [Required]
        public DateTime Horario { get; set; }
    }
}
