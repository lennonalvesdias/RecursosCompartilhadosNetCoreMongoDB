using MediatR;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace Base.WebApi.Controllers
{
    public class DefaultController : BaseController
    {
        public DefaultController(INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {

        }
    }
}
