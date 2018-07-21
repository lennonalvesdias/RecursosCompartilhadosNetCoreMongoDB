using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntidade, TViewModel> : IDisposable where TEntidade : IBaseEntidade where TViewModel : IBaseEntidade
    {
        TViewModel Inserir(TEntidade viewModel);
        TViewModel Buscar(string id);
        IList<TViewModel> Listar();
        TViewModel Atualizar(TEntidade viewModel);
        void Remover(string id);
        int Salvar();
    }
}