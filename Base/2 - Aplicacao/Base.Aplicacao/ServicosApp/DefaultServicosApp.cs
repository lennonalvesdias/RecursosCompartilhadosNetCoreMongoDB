using AutoMapper;
using Base.Aplicacao.Interfaces.ServicosApp;
using Base.Aplicacao.ViewModels;
using Base.Dominio.Entidades;
using Base.Dominio.Interfaces.Servicos;
using MongoDB.Driver;
using RecursosCompartilhados.Aplicacao.AutoMapper;
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

        Expression<Func<Default, bool>> GetMappedSelector(Expression<Func<DefaultSendViewModel, bool>> selector)
        {
            Expression<Func<Default, DefaultSendViewModel>> mapper = Mapper.CreateMapExpression<Default, DefaultSendViewModel>();
            Expression<Func<Default, bool>> mappedSelector = selector.Compose(mapper);
            return mappedSelector;
        }

        #region Buscar

        public DefaultReturnViewModel Buscar(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            var viewModel = _mapper.Map<DefaultReturnViewModel>(_servicos.Buscar(GetMappedSelector(filtro)));
            return viewModel;
        }

        public async Task<DefaultReturnViewModel> BuscarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            var viewModel = _mapper.Map<DefaultReturnViewModel>(await _servicos.BuscarAsync(filtro));
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
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(_servicos.Listar(filtro));
            return viewModels;
        }

        public IList<DefaultReturnViewModel> Listar<TKey>(Expression<Func<DefaultSendViewModel, TKey>> ordernarPor, Expression<Func<DefaultSendViewModel, bool>> filtro = null)
        {
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(_servicos.Listar(ordernarPor, filtro));
            return viewModels;
        }

        public async Task<IList<DefaultReturnViewModel>> ListarAsync<TKey>(Expression<Func<DefaultSendViewModel, TKey>> ordernarPor, Expression<Func<DefaultSendViewModel, bool>> filtro = null)
        {
            var viewModels = _mapper.Map<IList<DefaultReturnViewModel>>(await _servicos.ListarAsync(ordernarPor, filtro));
            return viewModels;
        }

        #endregion

        #region Inserir

        public DefaultReturnViewModel Inserir(DefaultSendViewModel entidade)
        {
            return _mapper.Map<DefaultReturnViewModel>(_servicos.Inserir(entidade));
        }

        public async Task<DefaultReturnViewModel> InserirAsync(DefaultSendViewModel entidade)
        {
            return _mapper.Map<DefaultReturnViewModel>(await _servicos.InserirAsync(entidade));
        }

        public IList<DefaultReturnViewModel> Inserir(IList<DefaultSendViewModel> entidades)
        {
            return _mapper.Map<IList<DefaultReturnViewModel>>(_servicos.Inserir(entidades));
        }

        public async Task<IList<DefaultReturnViewModel>> InserirAsync(IList<DefaultSendViewModel> entidades)
        {
            return _mapper.Map<IList<DefaultReturnViewModel>>(await _servicos.InserirAsync(entidades));
        }

        #endregion

        #region Editar

        public bool Editar(Expression<Func<DefaultSendViewModel, bool>> filtro, DefaultSendViewModel entidade)
        {
            return _servicos.Editar(filtro, entidade);
        }

        public async Task<bool> EditarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, DefaultSendViewModel entidade)
        {
            return await _servicos.EditarAsync(filtro, entidade);
        }

        #endregion

        #region Atualizar

        public bool Atualizar(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            return _servicos.Atualizar(filtro, entidade);
        }

        public async Task<bool> AtualizarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            return await _servicos.AtualizarAsync(filtro, entidade);
        }

        public bool AtualizarTodos(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            return _servicos.AtualizarTodos(filtro, entidade);
        }

        public async Task<bool> AtualizarTodosAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, UpdateDefinition<DefaultSendViewModel> entidade)
        {
            return await _servicos.AtualizarTodosAsync(filtro, entidade);
        }

        #endregion

        #region Deletar

        public bool Deletar(Expression<Func<DefaultSendViewModel, bool>> filtro)
        {
            return _servicos.Deletar(filtro);
        }

        public async Task<bool> DeletarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro)
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

        public long Contar(Expression<Func<DefaultSendViewModel, bool>> filtro, CountOptions opcoes = null)
        {
            return _servicos.Contar(filtro, opcoes);
        }

        public async Task<long> ContarAsync(Expression<Func<DefaultSendViewModel, bool>> filtro, CountOptions opcoes = null)
        {
            return await _servicos.ContarAsync(filtro, opcoes);
        }

        #endregion
    }
}
