using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class UpdateContaDto
    {

        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public long AgenciaId { get; set; }
        [Required]
        public long ClienteId { get; set; }
    }
}
