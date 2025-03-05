using System.Net;

namespace CRMFronted.Servicios
{
    public class HttpResponseWrapper<T>
    {
        public T? Response { get; set; }
        public bool Error { get; set; }
        public HttpResponseMessage? HttpResponseMessage { get; set; }

        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage? httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public async Task<string> GetErrorMessage()
        {
            if (!Error)
            {
                return null;
            }

            var codigoEstatus = HttpResponseMessage!.StatusCode;
            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "Elemento no encontrado";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return "Tienes que logearte para hacer esta operación";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para hacer esta operación";
            }
            return "Ha ocurrido un error inesperado";
        }
    }

}
