using AutoMapper;
using Base.Aplicacao.ViewModels;
using Base.Dominio.Entidades;

namespace Base.Aplicacao.AutoMapper
{
    public class EntidadeViewModelMappingProfile : Profile
    {
        public EntidadeViewModelMappingProfile()
        {
            CreateMap<Default, DefaultReturnViewModel>();
        }
    }
}
