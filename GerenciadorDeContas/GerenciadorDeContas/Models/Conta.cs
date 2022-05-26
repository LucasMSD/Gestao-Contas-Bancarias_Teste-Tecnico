using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Models
{
    public class Conta
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public long Numero { get; set; }
        [Required]
        public long AgenciaId { get; set; }
        public virtual Agencia Agencia { get; set; }
        public decimal Saldo { get; set; }
        [Required]
        public long ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
