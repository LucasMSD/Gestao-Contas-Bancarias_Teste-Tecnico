using AutoMapper;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
