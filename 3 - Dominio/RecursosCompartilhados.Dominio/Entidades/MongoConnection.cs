namespace RecursosCompartilhados.Dominio.Entidades
{
    public class MongoConnection
    {
        public string ConnectionString { get; set; }
        public string SecondaryConnectionString { get; set; }
        public string ExtractionConnectionString { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
