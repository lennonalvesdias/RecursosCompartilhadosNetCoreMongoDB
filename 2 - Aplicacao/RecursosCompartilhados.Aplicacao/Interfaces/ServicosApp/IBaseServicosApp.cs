using MongoDB.Driver;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntidade, TViewModel> where TEntidade : IBaseEntidade where TViewModel : IBaseEntidade
    {
        TViewModel Buscar(Expression<Func<TEntidade, bool>> filtro);
        Task<TViewModel> BuscarAsync(Expression<Func<TEntidade, bool>> filtro);

        IList<TViewModel> Listar();
        Task<IList<TViewModel>> ListarAsync();
        IList<TViewModel> Listar(Expression<Func<TEntidade, bool>> filtro);
        IList<TViewModel> Listar<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null);
        Task<IList<TViewModel>> ListarAsync<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null);

        TViewModel Inserir(TEntidade entidade);
        Task<TViewModel> InserirAsync(TEntidade entidade);
        IList<TViewModel> Inserir(IList<TEntidade> entidades);
        Task<IList<TViewModel>> InserirAsync(IList<TEntidade> entidades);

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
    }
}