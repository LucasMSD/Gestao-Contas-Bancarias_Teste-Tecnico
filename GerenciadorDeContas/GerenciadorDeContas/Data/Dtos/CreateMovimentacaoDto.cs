using GerenciadorDeContas.ContasBancarias.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class CreateMovimentacaoDto
    {
        [Required]
        public long ContaDestinoId { get; set; }
        [Required]
        public long ContaDestinoNumero { get; set; }
        public long ContaOrigemId { get; set; }
        public long ContaOrigemNumero { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        [Required]
        public DateTime Horario { get; set; }
    }
}
