using GerenciadorDeContas.ContasBancarias.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class ReadAgenciaDto
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public long Numero { get; set; }
        [Required]
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
