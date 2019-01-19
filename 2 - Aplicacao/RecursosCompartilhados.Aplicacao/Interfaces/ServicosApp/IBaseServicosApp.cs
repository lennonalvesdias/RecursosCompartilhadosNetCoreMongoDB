using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntidade, TViewModel> : IDisposable where TEntidade : IBaseEntidade where TViewModel : IBaseEntidade
    {
        TViewModel Inserir(TEntidade viewModel);
        TViewModel Buscar(Expression<Func<TEntidade, bool>> filter);
        IList<TViewModel> Listar(Expression<Func<TEntidade, bool>> filter);
        TViewModel Atualizar(TEntidade viewModel);
        void Remover(Expression<Func<TEntidade, bool>> filter);
        int Salvar();
    }
}