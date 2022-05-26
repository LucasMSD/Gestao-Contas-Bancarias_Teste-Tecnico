using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual List<Conta> Contas { get; set; }
    }
}
