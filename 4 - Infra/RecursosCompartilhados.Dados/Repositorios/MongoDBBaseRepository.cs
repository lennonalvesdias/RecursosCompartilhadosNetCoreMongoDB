using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;
using RecursosCompartilhados.Dominio.Entidades;
using System;
using System.Diagnostics;

namespace RecursosCompartilhados.Dados.Repositorios
{
    public class MongoDBBaseRepository
    {
        protected IMongoDatabase _database;

        public MongoDBBaseRepository()
        {
            try
            {
                string connectionString = DIConfiguration.ConfigurationService.GetOptions<MongoConnection>().ConnectionString;
                string dbName = DIConfiguration.ConfigurationService.GetOptions<MongoConnection>().Database;
                var conString = string.Format(connectionString, DIConfiguration.ConfigurationService.GetOptions<MongoConnection>().User, DIConfiguration.ConfigurationService.GetOptions<MongoConnection>().Password);

                var mongoClient = new MongoClient(conString);
                var mongoDatabaseSettings = new MongoDatabaseSettings();
                _database = mongoClient.GetDatabase(dbName, mongoDatabaseSettings);

                RegisterConventions();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor. ", ex);
            }
        }

        public static void RegisterConventions()
        {
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", new ConventionPack { new CamelCaseElementNameConvention() }, t => true);
            var ignoreExtraElementsConvention = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", ignoreExtraElementsConvention, type => true);
            ConventionRegistry.Register("DictionaryRepresentationConvention", new ConventionPack { new DictionaryRepresentationConvention(DictionaryRepresentation.ArrayOfArrays) }, _ => true);
        }
    }

    public class DictionaryRepresentationConvention : ConventionBase, IMemberMapConvention
    {
        private readonly DictionaryRepresentation _dictionaryRepresentation;

        public DictionaryRepresentationConvention(DictionaryRepresentation dictionaryRepresentation)
        {
            _dictionaryRepresentation = dictionaryRepresentation;
        }

        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.ClassMap.ClassType.Name == memberMap.MemberType.Name)
            {
                return;
            }
            Debug.WriteLine(memberMap.ClassMap.ClassType.Name + "." + memberMap.MemberName);
            memberMap.SetSerializer(ConfigureSerializer(memberMap.GetSerializer()));
        }

        private IBsonSerializer ConfigureSerializer(IBsonSerializer serializer)
        {
            if (serializer is IDictionaryRepresentationConfigurable dictionaryRepresentationConfigurable)
            {
                serializer = dictionaryRepresentationConfigurable.WithDictionaryRepresentation(_dictionaryRepresentation);
            }

            return !(serializer is IChildSerializerConfigurable childSerializerConfigurable)
                ? serializer
                : childSerializerConfigurable.WithChildSerializer(ConfigureSerializer(childSerializerConfigurable.ChildSerializer));
        }
    }
}
