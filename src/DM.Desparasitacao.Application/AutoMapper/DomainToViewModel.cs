using AutoMapper;
using DM.Desparasitacao.Application.ViewModels;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<AdministracaoRemedio, AdministracaoRemedioViewModel>().ReverseMap();
            CreateMap<DiaProtocoloLua, DiaProtocoloLuaViewModel>().ReverseMap();
            CreateMap<FaseDaLua, FaseDaLuaViewModel>().ReverseMap();
            CreateMap<ProtocoloLua, ProtocoloLuaViewModel>().ReverseMap();
            CreateMap<Remedio, RemedioViewModel>().ReverseMap();
            CreateMap<Lua, LuaViewModel>().ReverseMap();
            CreateMap<Horario, HorarioViewModel>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
        }
    }
}