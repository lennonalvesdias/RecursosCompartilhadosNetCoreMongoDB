using System.Collections.Generic;
using AutoMapper;

namespace RecursosCompartilhados.Aplicacao.ViewModel
{
    public class EntidadeGenerica<TViewModel, IBaseEntidade>
    {
        private readonly MapperConfiguration _mapperConfiguration;

        public EntidadeGenerica()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<TViewModel, IBaseEntidade>());
        }

        public IBaseEntidade ConverterViewModelEntidade(TViewModel vm)
        {
            var mapper = new Mapper(_mapperConfiguration);
            return mapper.Map<TViewModel, IBaseEntidade>(vm);
        }

        public IList<IBaseEntidade> ConverterListaViewModelEntidade(IList<TViewModel> vm)
        {
            var mapper = new Mapper(_mapperConfiguration);
            return mapper.Map<IList<TViewModel>, IList<IBaseEntidade>>(vm);
        }
    }
}