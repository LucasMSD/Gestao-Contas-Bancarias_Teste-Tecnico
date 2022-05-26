using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Models
{
    public class Agencia
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public long Numero { get; set; }
        [Required]
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual List<Conta> Contas { get; set; }
    }
}
