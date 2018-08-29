using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RecursosCompartilhados.Dados.Interfaces;
using RecursosCompartilhados.Dados.Repositorios;
using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

public abstract class BaseRepositorio<TEntidade> : IBaseRepositorio<TEntidade> where TEntidade : IBaseEntidade, new()
{
    protected IMongoCollection<TEntidade> Colecao { get; private set; }
    protected string NomeColecao { get; private set; }
    protected IConexao Conexao { get; private set; }

    protected BaseRepositorio(IConexao conexao)
    {
        SetNomeColecao();
        SetConexaoColecao(conexao);
    }

    #region Buscar

    public TEntidade Buscar(Expression<Func<TEntidade, bool>> filtro)
    {
        return Colecao.Find(filtro).FirstOrDefault();
    }

    public async Task<TEntidade> BuscarAsync(Expression<Func<TEntidade, bool>> filtro)
    {
        var resultado = await Colecao.FindAsync(filtro);
        return resultado.FirstOrDefault();
    }

    #endregion

    #region Listar

    public IList<TEntidade> Listar()
    {
        return Colecao.AsQueryable().ToList();
    }

    public async Task<IList<TEntidade>> ListarAsync()
    {
        return await Colecao.AsQueryable().ToListAsync();
    }

    public IList<TEntidade> Listar(Expression<Func<TEntidade, bool>> filtro)
    {
        return Queryable.Where(Colecao.AsQueryable(), filtro).ToList();
    }

    public IList<TEntidade> Listar<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null)
    {
        var query = Colecao.AsQueryable();
        if (filtro != null)
        {
            return query.Where(filtro).OrderBy(ordernarPor).ToList();
        }
        return query.OrderBy(ordernarPor).ToList();
    }

    public async Task<IList<TEntidade>> ListarAsync<TKey>(Expression<Func<TEntidade, TKey>> ordernarPor, Expression<Func<TEntidade, bool>> filtro = null)
    {
        var query = Colecao.AsQueryable();
        if (filtro != null)
        {
            return await query.Where(filtro).OrderBy(ordernarPor).ToListAsync();
        }
        return await query.OrderBy(ordernarPor).ToListAsync();
    }

    #endregion

    #region Inserir

    public TEntidade Inserir(TEntidade entidade)
    {
        entidade.Id = GerarChaveUnica().ToString();
        entidade.DataCriacaoRegistro = DateTime.Now;
        entidade.DataAtualizacaoRegistro = DateTime.Now;
        Colecao.InsertOne(entidade);
        return entidade;
    }

    public async Task<TEntidade> InserirAsync(TEntidade entidade)
    {
        entidade.Id = GerarChaveUnica().ToString();
        entidade.DataCriacaoRegistro = DateTime.Now;
        entidade.DataAtualizacaoRegistro = DateTime.Now;
        await Colecao.InsertOneAsync(entidade);
        return entidade;
    }

    public IList<TEntidade> Inserir(IList<TEntidade> entidades)
    {
        foreach (var entidade in entidades)
        {
            entidade.Id = GerarChaveUnica().ToString();
            entidade.DataCriacaoRegistro = DateTime.Now;
            entidade.DataAtualizacaoRegistro = DateTime.Now;
        }
        Colecao.InsertMany(entidades);
        return entidades;
    }

    public async Task<IList<TEntidade>> InserirAsync(IList<TEntidade> entidades)
    {
        foreach (var entidade in entidades)
        {
            entidade.Id = GerarChaveUnica().ToString();
            entidade.DataCriacaoRegistro = DateTime.Now;
            entidade.DataAtualizacaoRegistro = DateTime.Now;
        }
        await Colecao.InsertManyAsync(entidades);
        return entidades;
    }

    #endregion

    #region Editar

    public bool Editar(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade)
    {
        entidade.DataAtualizacaoRegistro = DateTime.Now;
        return Colecao.ReplaceOne(filtro, entidade).ModifiedCount > 0;
    }

    public async Task<bool> EditarAsync(Expression<Func<TEntidade, bool>> filtro, TEntidade entidade)
    {
        entidade.DataAtualizacaoRegistro = DateTime.Now;
        var resultado = await Colecao.ReplaceOneAsync(filtro, entidade);
        return resultado.ModifiedCount > 0;
    }

    #endregion

    #region Atualizar

    public bool Atualizar(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
    {
        entidade.Set("DataAtualizacaoRegistro", DateTime.Now);
        return Colecao.UpdateOne(filtro, entidade).ModifiedCount > 0;
    }

    public async Task<bool> AtualizarAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
    {
        entidade.Set("DataAtualizacaoRegistro", DateTime.Now);
        var resultado = await Colecao.UpdateOneAsync(filtro, entidade);
        return resultado.ModifiedCount > 0;
    }

    public bool AtualizarTodos(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
    {
        entidade.Set("DataAtualizacaoRegistro", DateTime.Now);
        return Colecao.UpdateMany(filtro, entidade).ModifiedCount > 0;
    }

    public async Task<bool> AtualizarTodosAsync(Expression<Func<TEntidade, bool>> filtro, UpdateDefinition<TEntidade> entidade)
    {
        entidade.Set("DataAtualizacaoRegistro", DateTime.Now);
        var resultado = await Colecao.UpdateManyAsync(filtro, entidade);
        return resultado.ModifiedCount > 0;
    }

    #endregion

    #region Deletar

    public bool Deletar(Expression<Func<TEntidade, bool>> filtro)
    {
        return Colecao.DeleteOne(filtro).DeletedCount > 0;
    }

    public async Task<bool> DeletarAsync(Expression<Func<TEntidade, bool>> filtro)
    {
        var resultado = await Colecao.DeleteOneAsync(filtro);
        return resultado.DeletedCount > 0;
    }

    #endregion

    #region Contar

    public long Contar()
    {
        return Colecao.Count(Builders<TEntidade>.Filter.Empty);
    }

    public async Task<long> ContarAsync()
    {
        return await Colecao.CountAsync(Builders<TEntidade>.Filter.Empty);
    }

    public long Contar(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null)
    {
        return Colecao.Count(filtro, opcoes);
    }

    public async Task<long> ContarAsync(Expression<Func<TEntidade, bool>> filtro, CountOptions opcoes = null)
    {
        return await Colecao.CountAsync(filtro, opcoes);
    }

    #endregion

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
                Colecao = null;
                Conexao = null;
            }
            _disposed = true;
        }
    }

    ~BaseRepositorio()
    {
        Dispose(false);
    }

    private bool _disposed;

    #endregion

    #region Funcoes de Apoio

    internal void SetNomeColecao()
    {
        var nomeColecao = (ColecaoMongo)typeof(TEntidade).GetTypeInfo().GetCustomAttribute(typeof(ColecaoMongo));
        NomeColecao = nomeColecao != null ? nomeColecao.NomeTabela : typeof(TEntidade).Name.ToLower();
    }

    public void SetNomeColecao(string colecao)
    {
        NomeColecao = colecao;
    }

    internal void SetConexaoColecao(IConexao conexao)
    {
        Conexao = conexao;
        Colecao = Conexao.Colecao<TEntidade>(NomeColecao);
    }

    private static Guid GerarChaveUnica()
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

    #endregion
}