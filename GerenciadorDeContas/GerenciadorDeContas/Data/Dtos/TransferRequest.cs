namespace GerenciadorDeContas.ContasBancarias.Data.Dtos
{
    public class TransferRequest
    {
        public long ContaOrigemNumero { get; set; }
        public long ContaDestinoNumero { get; set; }
        public decimal Valor { get; set; }
    }
}
