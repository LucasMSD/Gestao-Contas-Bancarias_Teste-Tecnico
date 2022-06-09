using AutoMapper;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Profiles
{
    public class MovimentacaoProfile : Profile
    {
        public MovimentacaoProfile()
        {
            CreateMap<DepositRequest, Movimentacao>();
            CreateMap<WithDrawRequest, Movimentacao>();
            CreateMap<TransferRequest, Movimentacao>();
        }
    }
}
