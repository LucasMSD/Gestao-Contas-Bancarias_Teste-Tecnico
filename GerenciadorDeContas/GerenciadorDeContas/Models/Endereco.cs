using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorDeContas.ContasBancarias.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        [StringLength(2)]
        public string UF { get; set; }
        [JsonIgnore]
        public virtual Agencia Agencia { get; set; }
    }
}
