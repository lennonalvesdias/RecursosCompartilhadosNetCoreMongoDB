using AutoMapper;
using Base.Aplicacao.Interfaces.ServicosApp;
using Base.Aplicacao.ViewModels;
using Base.Dominio.Entidades;
using Base.Dominio.Interfaces.Servicos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Base.Aplicacao.ServicosApp
{
    public class DefaultServicosApp : IDefaultServicosApp
    {
        private readonly IDefaultServicos _servicos;
        private readonly IMapper _mapper;

        public DefaultServicosApp(IDefaultServicos servicos, IMapper mapper)
        {
            _servicos = servicos;
            _mapper = mapper;
        }

        #region Buscar

        public DefaultReturnViewModel Buscar(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var viewModel = _mapper.Map<DefaultReturnViewModel>(_servicos.Buscar(mapFiltro));
            return viewModel;
        }

        public async Task<DefaultReturnViewModel> BuscarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var viewModel = _mapper.Map<DefaultReturnViewModel>(await _servicos.BuscarAsync(mapFiltro));
            return viewModel;
        }

        #endregion

        #region Listar

        public IList<DefaultReturnViewModel> Listar()
        {
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(_servicos.Listar());
            return viewModels;
        }

        public async Task<IList<DefaultReturnViewModel>> ListarAsync()
        {
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(await _servicos.ListarAsync());
            return viewModels;
        }

        public IList<DefaultReturnViewModel> Listar(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(_servicos.Listar(mapFiltro));
            return viewModels;
        }

        public IList<DefaultReturnViewModel> Listar<TKey>(Expression<Func<DefaultSendViewModel, TKey>> ordernarPor, Expression<Func<DefaultSendViewModel, bool>> filtro = null)
        {
            var mapOrdenarPor = _mapper.Map<Expression<Func<Default, TKey>>>(ordernarPor);
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(_servicos.Listar(mapOrdenarPor, mapFiltro));
            return viewModels;
        }

        public async Task<IList<DefaultReturnViewModel>> ListarAsync<TKey>(Expression<Func<DefaultSendViewModel, TKey>> ordernarPor, Expression<Func<DefaultSendViewModel, bool>> filtro = null)
        {
            var mapOrdenarPor = _mapper.Map<Expression<Func<Default, TKey>>>(ordernarPor);
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(await _servicos.ListarAsync(mapOrdenarPor, mapFiltro));
            return viewModels;
        }

        #endregion

        #region Inserir

        public DefaultReturnViewModel Inserir(DefaultSendViewModel viewModel)
        {
            var mapEntidade = _mapper.Map<Default>(viewModel);
            return _mapper.Map<DefaultReturnViewModel>(_servicos.Inserir(mapEntidade));
        }

        public async Task<DefaultReturnViewModel> InserirAsync(DefaultSendViewModel viewModel)
        {
            var mapEntidade = _mapper.Map<Default>(viewModel);
            return _mapper.Map<DefaultReturnViewModel>(await _servicos.InserirAsync(mapEntidade));
        }

        public IList<DefaultReturnViewModel> Inserir(IList<DefaultSendViewModel> viewModels)
        {
            var mapEntidades = _mapper.Map<IList<Default>>(viewModels);
            return _mapper.Map<IList<DefaultReturnViewModel>>(_servicos.Inserir(mapEntidades));
        }

        public async Task<IList<DefaultReturnViewModel>> InserirAsync(IList<DefaultSendViewModel> viewModels)
        {
            var mapEntidades = _mapper.Map<IList<Default>>(viewModels);
            return _mapper.Map<IList<DefaultReturnViewModel>>(await _servicos.InserirAsync(mapEntidades));
        }

        #endregion

        #region Editar

        public bool Editar(Expression<Func<DefaultSendViewModel, bool>> filtro, DefaultSendViewModel viewModel)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var mapEntidade = _mapper.Map<Default>(filtro);
            return _servicos.Editar(mapFiltro, mapEntidade);
        }

        public async Task<bool> EditarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, DefaultSendViewModel entidade)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var mapEntidade = _mapper.Map<Default>(filtro);
            return await _servicos.EditarAsync(mapFiltro, mapEntidade);
        }

        #endregion

        #region Atualizar

        public bool Atualizar(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var mapEntidade = _mapper.Map<UpdateDefinition<Default>>(filtro);
            return _servicos.Atualizar(mapFiltro, mapEntidade);
        }

        public async Task<bool> AtualizarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var mapEntidade = _mapper.Map<UpdateDefinition<Default>>(filtro);
            return await _servicos.AtualizarAsync(mapFiltro, mapEntidade);
        }

        public bool AtualizarTodos(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var mapEntidade = _mapper.Map<UpdateDefinition<Default>>(filtro);
            return _servicos.AtualizarTodos(mapFiltro, mapEntidade);
        }

        public async Task<bool> AtualizarTodosAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            var mapEntidade = _mapper.Map<UpdateDefinition<Default>>(filtro);
            return await _servicos.AtualizarTodosAsync(mapFiltro, mapEntidade);
        }

        #endregion

        #region Deletar

        public bool Deletar(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            return _servicos.Deletar(mapFiltro);
        }

        public async Task<bool> DeletarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            return await _servicos.DeletarAsync(mapFiltro);
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

        public long Contar(Expression<Func<DefaultSendViewModel, bool>> filtro, CountOptions opcoes = null)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            return _servicos.Contar(mapFiltro, opcoes);
        }

        public async Task<long> ContarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, CountOptions opcoes = null)
        {
            var mapFiltro = _mapper.Map<Expression<Func<Default, bool>>>(filtro);
            return await _servicos.ContarAsync(mapFiltro, opcoes);
        }

        #endregion
    }
}
