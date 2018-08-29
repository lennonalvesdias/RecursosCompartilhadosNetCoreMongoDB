using Base.Aplicacao.ViewModels;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;

namespace Base.Aplicacao.Interfaces.ServicosApp
{
    public interface IDefaultServicosApp : IBaseServicosApp<DefaultSendViewModel, DefaultReturnViewModel>
    {
    }
}
