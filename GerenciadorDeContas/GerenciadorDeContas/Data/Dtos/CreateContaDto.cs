using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class CreateContaDto
    {
        [Required]
        public long AgenciaId { get; set; }
        [Required]
        public long ClienteId { get; set; }
    }
}
