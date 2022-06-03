using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class UpdateAgenciaDto
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public long Numero { get; set; }
        [Required]
        public long EnderecoId { get; set; }
    }
}
