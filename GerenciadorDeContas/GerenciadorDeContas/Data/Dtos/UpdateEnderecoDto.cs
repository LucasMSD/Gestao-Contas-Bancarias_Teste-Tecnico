using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class UpdateEnderecoDto
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
    }
}
