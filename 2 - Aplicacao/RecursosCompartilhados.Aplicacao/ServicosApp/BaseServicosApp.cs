using System;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using System.Collections.Generic;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using AutoMapper;

namespace RecursosCompartilhados.Aplicacao.ServicosApp
{
    public abstract class BaseServicosApp<TEntidade, TViewModel> : IBaseServicosApp<TEntidade, TViewModel> where TEntidade : IBaseEntidade where TViewModel : IBaseEntidade
    {
        private readonly IBaseServicos<TEntidade> _servicos;
        private readonly IMapper _mapper;

        protected BaseServicosApp(IBaseServicos<TEntidade> servicos)
        {
            _servicos = servicos;
        }

        void IBaseServicosApp<TEntidade, TViewModel>.Atualizar(TEntidade entidade)
        {
            _servicos.Atualizar(entidade);
        }

        TViewModel IBaseServicosApp<TEntidade, TViewModel>.Buscar(Guid id)
        {
            var entidade = _servicos.Buscar(id);
            var viewModel = _mapper.Map<TViewModel>(entidade);
            return viewModel;
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<TEntidade, TViewModel>.Inserir(TEntidade entidade)
        {
            _servicos.Inserir(entidade);
        }

        IList<TViewModel> IBaseServicosApp<TEntidade, TViewModel>.Listar()
        {
            var listaEntidade = _servicos.Listar();
            var listaViewModel = _mapper.Map<IList<TViewModel>>(listaEntidade);
            return listaViewModel;
        }

        void IBaseServicosApp<TEntidade, TViewModel>.Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        int IBaseServicosApp<TEntidade, TViewModel>.Salvar()
        {
            return _servicos.Salvar();
        }
    }
}