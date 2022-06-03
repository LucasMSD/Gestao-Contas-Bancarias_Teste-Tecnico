using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class CreateAgenciaDto
    {
        [Required]
        public long Numero { get; set; }
        [Required]
        public long EnderecoId { get; set; }
    }
}
