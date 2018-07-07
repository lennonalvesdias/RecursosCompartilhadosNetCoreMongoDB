using System.Collections.Generic;
using AutoMapper;

namespace RecursosCompartilhados.Aplicacao.ViewModel
{
    public class EntidadeGenerica<TViewModel, IBaseEntidade>
    {
        public EntidadeGenerica()
        {
            Mapper.Initialize(config => config.CreateMap<TViewModel, IBaseEntidade>());
        }

        public static IBaseEntidade ConverterViewModelEntidade(TViewModel vm)
        {
            Mapper.Initialize(config => config.CreateMap<TViewModel, IBaseEntidade>());
            return Mapper.Map<TViewModel, IBaseEntidade>(vm);
        }

        public static IList<IBaseEntidade> ConverterListaViewModelEntidade(IList<TViewModel> vm)
        {
            return Mapper.Map<IList<TViewModel>, IList<IBaseEntidade>>(vm);
        }
    }
}