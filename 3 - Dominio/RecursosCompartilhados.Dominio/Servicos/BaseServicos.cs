using System;
using System.Collections.Generic;
using System.Linq;
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

        TEntidade IBaseServicos<TEntidade>.Atualizar(TEntidade entidade)
        {
            return _repositorio.Atualizar(entidade);
        }

        TEntidade IBaseServicos<TEntidade>.Buscar(Guid id)
        {
            return _repositorio.Buscar(id);
        }

        TEntidade IBaseServicos<TEntidade>.Inserir(TEntidade entidade)
        {
            return _repositorio.Inserir(entidade);
        }

        IList<TEntidade> IBaseServicos<TEntidade>.Listar()
        {
            return _repositorio.Listar().ToList();
        }

        void IBaseServicos<TEntidade>.Remover(Guid id)
        {
            _repositorio.Remover(id);
        }

        int IBaseServicos<TEntidade>.Salvar()
        {
            return _repositorio.Salvar();
        }
    }
}