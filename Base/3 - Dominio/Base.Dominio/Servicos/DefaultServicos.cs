using Base.Dominio.Entidades;
using Base.Dominio.Interfaces.Repositorios;
using Base.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Servicos;

namespace Base.Dominio.Servicos
{
    public class DefaultServicos : BaseServicos<Default>, IDefaultServicos
    {
        private readonly IDefaultRepositorio _repositorio;

        public DefaultServicos(IDefaultRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
