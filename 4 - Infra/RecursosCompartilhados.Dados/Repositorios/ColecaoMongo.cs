using System;
using System.Runtime.InteropServices;

namespace RecursosCompartilhados.Dados.Repositorios
{
    [AttributeUsage(AttributeTargets.Class)]
    [ComVisible(true)]
    public class ColecaoMongo : Attribute
    {
        public string NomeTabela { get; }
        public ColecaoMongo(string nomeTabela)
        {
            this.NomeTabela = nomeTabela;
        }
    }
}
