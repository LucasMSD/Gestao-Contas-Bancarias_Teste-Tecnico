using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class DepositRequest
    {
        [Required]
        public long ContaDestinoNumero { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
