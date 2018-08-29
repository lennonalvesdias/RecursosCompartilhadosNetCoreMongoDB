using AutoMapper;
using Base.Aplicacao.ViewModels;
using Base.Dominio.Entidades;

namespace Base.Aplicacao.AutoMapper
{
    public class ViewModelEntidadeMappingProfile : Profile
    {
        public ViewModelEntidadeMappingProfile()
        {
            CreateMap<DefaultSendViewModel, Default>();
        }
    }
}
