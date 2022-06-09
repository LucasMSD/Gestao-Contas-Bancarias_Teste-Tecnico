namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class TransferResponse
    {
        public long Numero { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoAtual { get; set; }
    }
}
