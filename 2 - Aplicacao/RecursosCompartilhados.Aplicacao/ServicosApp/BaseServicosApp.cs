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

        TViewModel IBaseServicosApp<TEntidade, TViewModel>.Atualizar(TEntidade entidade)
        {
            var viewModel = _mapper.Map<TViewModel>(_servicos.Atualizar(entidade));
            return viewModel;
        }

        TViewModel IBaseServicosApp<TEntidade, TViewModel>.Buscar(string id)
        {
            var entidade = _servicos.Buscar(id);
            var viewModel = _mapper.Map<TViewModel>(entidade);
            return viewModel;
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        TViewModel IBaseServicosApp<TEntidade, TViewModel>.Inserir(TEntidade entidade)
        {
            var viewModel = _mapper.Map<TViewModel>(_servicos.Inserir(entidade));
            return viewModel;
        }

        IList<TViewModel> IBaseServicosApp<TEntidade, TViewModel>.Listar()
        {
            var listaEntidade = _servicos.Listar();
            var listaViewModel = _mapper.Map<IList<TViewModel>>(listaEntidade);
            return listaViewModel;
        }

        void IBaseServicosApp<TEntidade, TViewModel>.Remover(string id)
        {
            _servicos.Remover(id);
        }

        int IBaseServicosApp<TEntidade, TViewModel>.Salvar()
        {
            return _servicos.Salvar();
        }
    }
}