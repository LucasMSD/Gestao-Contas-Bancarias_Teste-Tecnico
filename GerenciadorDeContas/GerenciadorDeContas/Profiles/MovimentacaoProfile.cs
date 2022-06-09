using AutoMapper;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Enums;
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
            CreateMap<Movimentacao, ExtratoDto>()
                .ForAllMembers(opt => opt.Condition((movimentacao, extrato) =>
                {
                    extrato.ContaOrigemTitular = movimentacao.ContaOrigem?.Cliente.Nome;
                    extrato.ContaDestinoTitular = movimentacao.ContaDestino?.Cliente.Nome;

                    return true;
                }));
        }
    }
}
