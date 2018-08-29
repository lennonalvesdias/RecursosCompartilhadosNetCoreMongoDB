using MongoDB.Driver;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecursosCompartilhados.Dominio.Servicos
{
    public abstract class BaseServicos<TEntidade> : IBaseServicos<TEntidade> where TEntidade : IBaseEntidade
    {
        private readonly IBaseRepositorio<TEntidade> _repositorio;

        protected BaseServicos(IBaseRepositorio<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        #region Buscar

        public TEntidade Buscar(Expression<Func<TEntidade, bool>> filtro)
        {
            return _repositorio.Buscar(filtro);
        }

        public async Task<TEntidade> BuscarAsync(Expression<Func<TEntidade, bool>> filtro)
        {
            return await _repositorio.BuscarAsync(filtro);
        }

        #endregion

        #region Listar

        public IList<TEntidade> Listar()
        {
            return _repositorio.Listar();
        }

        public async Task<IList<TEntidade>> ListarAsync()
        {
            return await _repositorio.ListarAsync();
        }

        public IList<TEntidade> Listar(Expression<Func<TEntidade, bool>> filtro)
        {
            return _repositorio.Listar(filtro);
        }

        public IList<TEntidade> Listar<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null)
        {
            return _repositorio.Listar(ordernarPor, filtro);
        }

        public async Task<IList<TEntidade>> ListarAsync<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null)
        {
            return await _repositorio.ListarAsync(ordernarPor, filtro);
        }

        #endregion

        #region Inserir

        public TEntidade Inserir(TEntidade entidade)
        {
            return _repositorio.Inserir(entidade);
        }

        public async Task<TEntidade> InserirAsync(TEntidade entidade)
        {
            return await _repositorio.InserirAsync(entidade);
        }

        public IList<TEntidade> Inserir(IList<TEntidade> entidades)
        {
            return _repositorio.Inserir(entidades);
        }

        public async Task<IList<TEntidade>> InserirAsync(IList<TEntidade> entidades)
        {
            return await _repositorio.InserirAsync(entidades);
        }

        #endregion

        #region Editar

        public bool Editar(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade)
        {
            return _repositorio.Editar(filtro, entidade);
        }

        public async Task<bool> EditarAsync(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade)
        {
            return await _repositorio.EditarAsync(filtro, entidade);
        }

        #endregion

        #region Atualizar

        public bool Atualizar(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return _repositorio.Atualizar(filtro, entidade);
        }

        public async Task<bool> AtualizarAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return await _repositorio.AtualizarAsync(filtro, entidade);
        }

        public bool AtualizarTodos(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return _repositorio.AtualizarTodos(filtro, entidade);
        }

        public async Task<bool> AtualizarTodosAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
        {
            return await _repositorio.AtualizarTodosAsync(filtro, entidade);
        }

        #endregion

        #region Deletar

        public bool Deletar(Expression<Func<TEntidade, bool>> filtro)
        {
            return _repositorio.Deletar(filtro);
        }

        public async Task<bool> DeletarAsync(Expression<Func<TEntidade, bool>> filtro)
        {
            return await _repositorio.DeletarAsync(filtro);
        }

        #endregion

        #region Contar

        public long Contar()
        {
            return _repositorio.Contar();
        }

        public async Task<long> ContarAsync()
        {
            return await _repositorio.ContarAsync();
        }

        public long Contar(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null)
        {
            return _repositorio.Contar(filtro, opcoes);
        }

        public async Task<long> ContarAsync(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null)
        {
            return await _repositorio.ContarAsync(filtro, opcoes);
        }

        #endregion
    }
}