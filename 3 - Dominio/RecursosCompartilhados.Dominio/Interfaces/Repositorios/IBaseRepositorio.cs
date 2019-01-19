using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RecursosCompartilhados.Dominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio<TEntidade> : IDisposable where TEntidade : IBaseEntidade
    {
        TEntidade Inserir(TEntidade entidade);
        TEntidade Buscar(Expression<Func<TEntidade, bool>> filter);
        IList<TEntidade> Listar(Expression<Func<TEntidade, bool>> filter);
        TEntidade Atualizar(TEntidade entidade);
        void Remover(Expression<Func<TEntidade, bool>> filter);
        int Salvar();
    }
}