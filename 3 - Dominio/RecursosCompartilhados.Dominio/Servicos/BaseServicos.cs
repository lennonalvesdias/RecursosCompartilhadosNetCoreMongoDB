using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;

namespace RecursosCompartilhados.Dominio.Servicos
{
    public abstract class BaseServicos<TEntidade> : IBaseServicos<TEntidade> where TEntidade : IBaseEntidade
    {
        private readonly IBaseRepositorio<TEntidade> _repositorio;

        protected BaseServicos(IBaseRepositorio<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        TEntidade IBaseServicos<TEntidade>.Buscar(Expression<Func<TEntidade, bool>> filter)
        {
            return _repositorio.Buscar(filter);
        }

        IList<TEntidade> IBaseServicos<TEntidade>.Listar(Expression<Func<TEntidade, bool>> filter)
        {
            return _repositorio.Listar(filter).ToList();
        }

        TEntidade IBaseServicos<TEntidade>.Inserir(TEntidade entidade)
        {
            return _repositorio.Inserir(entidade);
        }

        TEntidade IBaseServicos<TEntidade>.Atualizar(TEntidade entidade)
        {
            return _repositorio.Atualizar(entidade);
        }

        void IBaseServicos<TEntidade>.Remover(Expression<Func<TEntidade, bool>> filter)
        {
            _repositorio.Remover(filter);
        }

        int IBaseServicos<TEntidade>.Salvar()
        {
            return _repositorio.Salvar();
        }
    }
}