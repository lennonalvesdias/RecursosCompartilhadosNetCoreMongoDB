using Base.Aplicacao.Interfaces.ServicosApp;
using Microsoft.AspNetCore.Mvc;

namespace Base.WebApi.Controllers
{
    public class DefaultController : ControllerBase
    {
        private readonly IDefaultServicosApp _servicosApp;

        public DefaultController(IDefaultServicosApp servicosApp)
        {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        [Route("default")]
        public IActionResult Get()
        {
            return Ok(_servicosApp.Listar());
        }
    }
}
