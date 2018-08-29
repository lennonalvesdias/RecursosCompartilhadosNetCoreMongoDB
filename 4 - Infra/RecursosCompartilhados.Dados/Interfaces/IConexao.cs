using MongoDB.Driver;
using System;

namespace RecursosCompartilhados.Dados.Interfaces
{
    public interface IConexao : IDisposable
    {
        IMongoCollection<TEntidade> Colecao<TEntidade>(string nomeColecao);
    }
}
