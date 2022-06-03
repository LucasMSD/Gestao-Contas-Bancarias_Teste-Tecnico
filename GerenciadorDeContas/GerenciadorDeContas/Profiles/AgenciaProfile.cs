using AutoMapper;
using GerenciadorDeContas.ContasBancarias.Data.Dtos;
using GerenciadorDeContas.ContasBancarias.Models;

namespace GerenciadorDeContas.ContasBancarias.Profiles
{
    public class AgenciaProfile : Profile
    {
        public AgenciaProfile()
        {
            CreateMap<CreateAgenciaDto, Agencia>();
            CreateMap<Agencia, ReadAgenciaDto>();
            CreateMap<UpdateAgenciaDto, Agencia>();
        }
    }
}
