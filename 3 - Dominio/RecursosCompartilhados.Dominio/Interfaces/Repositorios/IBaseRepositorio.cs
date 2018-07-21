using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;

namespace RecursosCompartilhados.Dominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio<TEntidade> : IDisposable where TEntidade : IBaseEntidade
    {
        TEntidade Inserir(TEntidade entidade);
        TEntidade Buscar(string id);
        IList<TEntidade> Listar();
        TEntidade Atualizar(TEntidade entidade);
        void Remover(string id);
        int Salvar();
    }
}