using RecursosCompartilhados.Aplicacao.ServicosExternos;
using RestSharp;
using System.Collections.Generic;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosExternos
{
    public interface IRestSharpClient
    {
        IRestResponse PostAsync(string url, string resource, object body,
            IDictionary<string, string> headers = null, IDictionary<string, string> simpleAuthentication = null, bool security = false,
            BodyType bodyType = BodyType.ApplicationJson);

        IRestResponse Get(string url, string resource, IDictionary<string, string> parameters = null,
            IDictionary<string, string> headers = null, IDictionary<string, string> simpleAuthentication = null, bool security = false,
            ParameterType parameterType = ParameterType.UrlSegment);
    }
}
