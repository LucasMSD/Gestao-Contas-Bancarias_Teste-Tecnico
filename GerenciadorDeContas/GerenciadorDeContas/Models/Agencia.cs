using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorDeContas.ContasBancarias.Models
{
    public class Agencia
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public long Numero { get; set; }
        [Required]
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        [JsonIgnore]
        public virtual List<Conta> Contas { get; set; }
    }
}
