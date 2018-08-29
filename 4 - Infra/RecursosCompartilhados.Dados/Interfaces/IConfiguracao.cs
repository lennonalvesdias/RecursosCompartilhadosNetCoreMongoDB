namespace RecursosCompartilhados.Dados.Interfaces
{
    public interface IConfiguracao
    {
        string MongoConnectionString { get; }
        string MongoDatabase { get; }
    }
}
