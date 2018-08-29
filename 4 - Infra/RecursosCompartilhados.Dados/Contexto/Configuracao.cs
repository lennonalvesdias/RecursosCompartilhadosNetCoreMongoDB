using Microsoft.Extensions.Configuration;
using RecursosCompartilhados.Dados.Interfaces;

namespace RecursosCompartilhados.Dados.Contexto
{
    public class Configuracao : IConfiguracao
    {
        private readonly IConfiguration _configuracao;

        public Configuracao(IConfiguration configuracao)
        {
            var sessao = configuracao.GetSection("MongoDB");
            MongoConnectionString = sessao["ConnectionStrings"];
            MongoDatabase = sessao["Database"];

            _configuracao = configuracao;
        }

        public Configuracao(string connectionString, string database)
        {
            MongoConnectionString = connectionString;
            MongoDatabase = database;
        }

        public string MongoConnectionString { get; }
        public string MongoDatabase { get; }
    }
}
