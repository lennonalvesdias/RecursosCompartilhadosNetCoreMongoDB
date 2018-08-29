using MongoDB.Driver;
using RecursosCompartilhados.Dados.Interfaces;
using System;

namespace RecursosCompartilhados.Dados.Contexto
{
    public class Conexao : IConexao
    {
        protected MongoClient Cliente { get; private set; }
        protected IMongoDatabase DataBase { get; private set; }

        public IMongoCollection<T> Colecao<T>(string collectionName)
        {
            return DataBase.GetCollection<T>(collectionName);
        }

        public Conexao(IConfiguracao config)
        {
            Cliente = new MongoClient(config.MongoConnectionString);
            DataBase = Cliente.GetDatabase(config.MongoDatabase);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DataBase = null;
                    Cliente = null;
                }

                _disposed = true;
            }
        }

        ~Conexao()
        {
            Dispose(false);
        }

        private bool _disposed;

        #endregion Dispose
    }
}
