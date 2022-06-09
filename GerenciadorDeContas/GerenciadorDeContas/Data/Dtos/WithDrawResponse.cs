namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class WithDrawResponse
    {
        public long Numero { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoAtual { get; set; }
    }
}
