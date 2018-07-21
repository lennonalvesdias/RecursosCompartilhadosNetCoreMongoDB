using MongoDB.Driver;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;

public abstract class BaseRepositorio<TEntidade> : IBaseRepositorio<TEntidade> where TEntidade : IBaseEntidade, new()
{
    protected BaseContexto contexto = new BaseContexto();

    public BaseRepositorio()
    {
    }

    public void Dispose()
    {
        return;
    }

    TEntidade IBaseRepositorio<TEntidade>.Atualizar(TEntidade entidade)
    {
        entidade.DataAtualizacaoRegistro = DateTime.Now;
        return BaseCollection.FindOneAndReplace(x => x.Id == entidade.Id, entidade);
    }

    TEntidade IBaseRepositorio<TEntidade>.Buscar(string id)
    {
        return BaseCollection.Find(x => x.Id == id).FirstOrDefault();
    }

    TEntidade IBaseRepositorio<TEntidade>.Inserir(TEntidade entidade)
    {
        entidade.Id = GenerateComb().ToString();
        entidade.DataCriacaoRegistro = DateTime.Now;
        entidade.DataAtualizacaoRegistro = DateTime.Now;
        BaseCollection.InsertOne(entidade);
        return entidade;
    }

    IList<TEntidade> IBaseRepositorio<TEntidade>.Listar()
    {
        return BaseCollection.Find(x => true).ToList();
    }

    void IBaseRepositorio<TEntidade>.Remover(string id)
    {
        BaseCollection.DeleteOne(x => x.Id == id);
    }

    int IBaseRepositorio<TEntidade>.Salvar()
    {
        return 0;
    }

    IMongoCollection<TEntidade> BaseCollection
    {
        get
        {
            {
                var collectionName = GetCollectionName();
                return contexto._database.GetCollection<TEntidade>(collectionName);
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

    private static Guid GenerateComb()
    {
        byte[] guidArray = Guid.NewGuid().ToByteArray();

        DateTime baseDate = new DateTime(1900, 1, 1);
        DateTime now = DateTime.Now;

        // Get the days and milliseconds which will be used to build the byte string 
        TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
        TimeSpan msecs = now.TimeOfDay;

        // Convert to a byte array 
        // Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333 
        byte[] daysArray = BitConverter.GetBytes(days.Days);
        byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

        // Reverse the bytes to match SQL Servers ordering 
        Array.Reverse(daysArray);
        Array.Reverse(msecsArray);

        // Copy the bytes into the guid 
        Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
        Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

        return new Guid(guidArray);
    }
}