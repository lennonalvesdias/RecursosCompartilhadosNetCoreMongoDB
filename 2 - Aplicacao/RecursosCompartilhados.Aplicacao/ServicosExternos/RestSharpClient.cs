using RecursosCompartilhados.Aplicacao.Interfaces.ServicosExternos;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RecursosCompartilhados.Aplicacao.ServicosExternos
{
    public class RestSharpClient : IRestSharpClient
    {
        public IRestResponse PostAsync(string url, string resource, object body,
            IDictionary<string, string> headers = null, IDictionary<string, string> simpleAuthentication = null, bool security = false,
            BodyType bodyType = BodyType.ApplicationJson)
        {
            /*switch (strategy)
            {
                case SerializerStrategy.SnakeJson:
                    SimpleJson.CurrentJsonSerializerStrategy = new SnakeJsonSerializerStrategy();
                    break;
                case SerializerStrategy.CamelCase:
                    SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseJsonSerializerStrategy();
                    break;
                default:
                    break;
            }*/

            if (security)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }

            var client = new RestClient(url);

            if (simpleAuthentication != null)
            {
                client.Authenticator = new HttpBasicAuthenticator(simpleAuthentication["username"], simpleAuthentication["password"]);
            }

            var request = new RestRequest(resource, Method.POST);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            switch (bodyType)
            {
                case BodyType.FormUrlEncoded:
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    dynamic parameters = body;
                    foreach (var param in parameters)
                    {
                        request.AddParameter(param.Key, param.Value);
                    }
                    break;
                case BodyType.Text:
                    break;
                case BodyType.TextPlain:
                    request.AddHeader("Content-Type", "text/plain");
                    break;
                case BodyType.ApplicationJson:
                    request.AddHeader("Content-Type", "application/json");
                    request.AddJsonBody(body);
                    break;
                case BodyType.ApplicationJavascript:
                    request.AddHeader("Content-Type", "application/javascript");
                    break;
                case BodyType.ApplicationXml:
                    request.AddHeader("Content-Type", "application/xml");
                    break;
                case BodyType.TextXml:
                    request.AddHeader("Content-Type", "text/xml");
                    break;
                case BodyType.TextHtml:
                    request.AddHeader("Content-Type", "text/html");
                    break;
                default:
                    break;
            }

            return client.Execute(request);
        }

        public IRestResponse Get(string url, string resource, IDictionary<string, string> parameters = null,
            IDictionary<string, string> headers = null, IDictionary<string, string> simpleAuthentication = null, bool security = false,
            ParameterType parameterType = ParameterType.UrlSegment)
        {
            if (security)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }

            var client = new RestClient(url);

            if (simpleAuthentication != null)
            {
                client.Authenticator = new HttpBasicAuthenticator(simpleAuthentication["username"], simpleAuthentication["password"]);
            }

            var request = new RestRequest(resource, Method.GET);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value, parameterType);
                }
            }

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            return client.Execute(request);
        }
    }

    class SnakeJsonSerializerStrategy : SimpleJson.PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            //PascalCase to snake_case
            return string.Concat(clrPropertyName.Select((x, i) => i == 0 ? char.ToLower(x).ToString() : i > 0 && char.IsUpper(x) ? "_" + char.ToLower(x).ToString() : x.ToString()));
        }
    }

    class CamelCaseJsonSerializerStrategy : SimpleJson.PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            //PascalCase to camelCase
            return string.Concat(clrPropertyName.Select((x, i) => i == 0 ? char.ToLower(x).ToString() : x.ToString()));
        }
    }

    public enum SerializerStrategy
    {
        SnakeJson = 0,
        CamelCase = 1
    }

    public enum BodyType
    {
        FormUrlEncoded = 0,
        Text = 1,
        TextPlain = 2,
        ApplicationJson = 3,
        ApplicationJavascript = 4,
        ApplicationXml = 5,
        TextXml = 6,
        TextHtml = 7
    }
}
