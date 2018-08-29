using Base.Dominio.Entidades;
using Base.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dados.Interfaces;

namespace Base.Dados.Repositorios
{
    public class DefaultRepositorio : BaseRepositorio<Default>, IDefaultRepositorio
    {
        protected DefaultRepositorio(IConexao conexao) : base(conexao)
        {
        }
    }
}
