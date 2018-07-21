using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;

namespace RecursosCompartilhados.Dominio.Interfaces.Servicos
{
    public interface IBaseServicos<TEntidade> : IDisposable where TEntidade : IBaseEntidade
    {
        TEntidade Inserir(TEntidade entidade);
        TEntidade Buscar(string id);
        IList<TEntidade> Listar();
        TEntidade Atualizar(TEntidade entidade);
        void Remover(string id);
        int Salvar();
    }
}