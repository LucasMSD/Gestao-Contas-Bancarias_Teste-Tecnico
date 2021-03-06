using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class UpdateClienteDto
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
    }
}
