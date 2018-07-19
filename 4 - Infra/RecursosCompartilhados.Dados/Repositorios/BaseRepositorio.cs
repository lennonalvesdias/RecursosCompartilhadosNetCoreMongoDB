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

    TEntidade IBaseRepositorio<TEntidade>.Buscar(Guid id)
    {
        return BaseCollection.Find(x => x.Id == id).FirstOrDefault();
    }

    TEntidade IBaseRepositorio<TEntidade>.Inserir(TEntidade entidade)
    {
        entidade.Id = Guid.NewGuid();
        entidade.DataCriacaoRegistro = DateTime.Now;
        entidade.DataAtualizacaoRegistro = DateTime.Now;
        BaseCollection.InsertOne(entidade);
        return entidade;
    }

    IList<TEntidade> IBaseRepositorio<TEntidade>.Listar()
    {
        return BaseCollection.Find(x => true).ToList();
    }

    void IBaseRepositorio<TEntidade>.Remover(Guid id)
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
}