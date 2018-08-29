using RecursosCompartilhados.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
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

        #region Buscar

        public TViewModel Buscar(Expression<Func<TEntidade, bool>> filtro)
        {
            var viewModel = _mapper.Map<TViewModel>(_servicos.Buscar(filtro));
            return viewModel;
        }

        public async Task<TViewModel> BuscarAsync(Expression<Func<TEntidade, bool>> filtro)
        {
            var viewModel = _mapper.Map<TViewModel>(await _servicos.BuscarAsync(filtro));
            return viewModel;
        }

        #endregion

        #region Listar

        public IList<TViewModel> Listar()
        {
            var viewModels = _mapper.Map<IList<TViewModel>>(_servicos.Listar());
            return viewModels;
        }

        public async Task<IList<TViewModel>> ListarAsync()
        {
            var viewModels = _mapper.Map<IList<TViewModel>>(await _servicos.ListarAsync());
            return viewModels;
        }

        public IList<TViewModel> Listar(Expression<Func<TEntidade, bool>> filtro)
        {
            var viewModels = _mapper.Map<IList<TViewModel>>(_servicos.Listar(filtro));
            return viewModels;
        }

        public IList<TViewModel> Listar<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null)
        {
            var viewModels = _mapper.Map<IList<TViewModel>>(_servicos.Listar(ordernarPor, filtro));
            return viewModels;
        }

        public async Task<IList<TViewModel>> ListarAsync<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null)
        {
            var viewModels = _mapper.Map<IList<TViewModel>>(await _servicos.ListarAsync(ordernarPor, filtro));
            return viewModels;
        }

        #endregion

        #region Inserir

        public TViewModel Inserir(TEntidade entidade)
        {
            return _mapper.Map<TViewModel>(_servicos.Inserir(entidade));
        }

        public async Task<TViewModel> InserirAsync(TEntidade entidade)
        {
            return _mapper.Map<TViewModel>(await _servicos.InserirAsync(entidade));
        }

        public IList<TViewModel> Inserir(IList<TEntidade> entidades)
        {
            return _mapper.Map<IList<TViewModel>>(_servicos.Inserir(entidades));
        }

        public async Task<IList<TViewModel>> InserirAsync(IList<TEntidade> entidades)
        {
            return _mapper.Map<IList<TViewModel>>(await _servicos.InserirAsync(entidades));
        }

        #endregion

        #region Editar

        public bool Editar(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade)
        {
            return _servicos.Editar(filtro, entidade);
        }

        public async Task<bool> EditarAsync(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade)
        {
            return await _servicos.EditarAsync(filtro, entidade);
        }

        #endregion

        #region Atualizar

        public bool Atualizar(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return _servicos.Atualizar(filtro, entidade);
        }

        public async Task<bool> AtualizarAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return await _servicos.AtualizarAsync(filtro, entidade);
        }

        public bool AtualizarTodos(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return _servicos.AtualizarTodos(filtro, entidade);
        }

        public async Task<bool> AtualizarTodosAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return await _servicos.AtualizarTodosAsync(filtro, entidade);
        }

        #endregion

        #region Deletar

        public bool Deletar(Expression<Func<TEntidade, bool>> filtro)
        {
            return _servicos.Deletar(filtro);
        }

        public async Task<bool> DeletarAsync(Expression<Func<TEntidade, bool>> filtro)
        {
            return await _servicos.DeletarAsync(filtro);
        }

        #endregion

        #region Contar

        public long Contar()
        {
            return _servicos.Contar();
        }

        public async Task<long> ContarAsync()
        {
            return await _servicos.ContarAsync();
        }

        public long Contar(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null)
        {
            return _servicos.Contar(filtro, opcoes);
        }

        public async Task<long> ContarAsync(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null)
        {
            return await _servicos.ContarAsync(filtro, opcoes);
        }

        #endregion
    }
}