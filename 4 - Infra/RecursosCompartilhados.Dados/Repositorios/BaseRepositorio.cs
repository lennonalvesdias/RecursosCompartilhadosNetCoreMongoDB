using MongoDB.Driver;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RecursosCompartilhados.Dados.Repositorios
{
    public abstract class BaseRepositorio<TEntidade> : MongoDBBaseRepository, IBaseRepositorio<TEntidade> where TEntidade : IBaseEntidade, new()
    {
        protected IMongoCollection<TEntidade> BaseCollection
        {
            get
            {
                {
                    return _database.GetCollection<TEntidade>(GetCollectionName());
                }
            }
        }

        protected virtual string GetCollectionName()
        {
            var collectionName = typeof(TEntidade).Name + "s";
            collectionName = collectionName.Replace("ys", "ies");
            if (collectionName.EndsWith("chs"))
            {
                collectionName = collectionName.Substring(0, collectionName.Length - 3) + "ches";
            }
            return collectionName;
        }

        public void Dispose()
        {
            return;
        }

        TEntidade IBaseRepositorio<TEntidade>.Buscar(Expression<Func<TEntidade, bool>> filter)
        {
            return BaseCollection.Find(filter).FirstOrDefault();
        }

        IList<TEntidade> IBaseRepositorio<TEntidade>.Listar(Expression<Func<TEntidade, bool>> filter)
        {
            return BaseCollection.Find(filter).ToList();
        }

        TEntidade IBaseRepositorio<TEntidade>.Inserir(TEntidade entidade)
        {
            entidade.Id = GenerateComb().ToString();
            entidade.DataCriacaoRegistro = DateTime.Now;
            entidade.DataAtualizacaoRegistro = DateTime.Now;
            BaseCollection.InsertOne(entidade);
            return entidade;
        }

        TEntidade IBaseRepositorio<TEntidade>.Atualizar(TEntidade entidade)
        {
            entidade.DataAtualizacaoRegistro = DateTime.Now;
            return BaseCollection.FindOneAndReplace(x => x.Id == entidade.Id, entidade);
        }

        void IBaseRepositorio<TEntidade>.Remover(Expression<Func<TEntidade, bool>> filter)
        {
            BaseCollection.DeleteMany(filter);
        }

        int IBaseRepositorio<TEntidade>.Salvar()
        {
            return 0;
        }

        private static Guid GenerateComb()
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();

            DateTime baseDate = new DateTime(1900, 1, 1);
            DateTime now = DateTime.Now;

            TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
            TimeSpan msecs = now.TimeOfDay;

            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }
    }
}