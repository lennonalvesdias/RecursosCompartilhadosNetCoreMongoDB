using MongoDB.Driver;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecursosCompartilhados.Dominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio<TEntidade> : IDisposable where TEntidade : IBaseEntidade
    {
        TEntidade Buscar(Expression<Func<TEntidade, bool>> filtro);
        Task<TEntidade> BuscarAsync(Expression<Func<TEntidade, bool>> filtro);

        IList<TEntidade> Listar();
        Task<IList<TEntidade>> ListarAsync();
        IList<TEntidade> Listar(Expression<Func<TEntidade, bool>> filtro);
        IList<TEntidade> Listar<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null);
        Task<IList<TEntidade>> ListarAsync<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null);

        TEntidade Inserir(TEntidade entidade);
        Task<TEntidade> InserirAsync(TEntidade entidade);
        IList<TEntidade> Inserir(IList<TEntidade> entidades);
        Task<IList<TEntidade>> InserirAsync(IList<TEntidade> entidades);

        bool Editar(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade);
        Task<bool> EditarAsync(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade);
        
        bool Atualizar(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade);
        Task<bool> AtualizarAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade);
        bool AtualizarTodos(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade);
        Task<bool> AtualizarTodosAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade);

        bool Deletar(Expression<Func<TEntidade, bool>> filtro);
        Task<bool> DeletarAsync(Expression<Func<TEntidade, bool>> filtro);

        long Contar();
        Task<long> ContarAsync();
        long Contar(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null);
        Task<long> ContarAsync(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null);

        void SetNomeColecao(string colecao);
    }
}