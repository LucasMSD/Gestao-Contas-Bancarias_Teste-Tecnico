using GerenciadorDeContas.ContasBancarias.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class ExtratoDto
    {
        public long? ContaDestinoNumero { get; set; }
        public string? ContaDestinoTitular { get; set; }
        public long? ContaOrigemNumero { get; set; }
        public string? ContaOrigemTitular { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        [EnumDataType(typeof(TipoMovimentacao))]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        [Required]
        public DateTime Horario { get; set; }
    }
}
