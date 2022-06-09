using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class WithDrawRequest
    {
        [Required]
        public long ContaOrigemNumero { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
