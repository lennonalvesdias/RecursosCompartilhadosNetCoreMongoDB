using System;

namespace RecursosCompartilhados.Dominio.Interfaces.Entidades
{
    public interface IBaseEntidade
    {
        string Id { get; set; }
        DateTime DataAtualizacaoRegistro { get; set; }

        DateTime DataCriacaoRegistro { get; set; }
    }
}
