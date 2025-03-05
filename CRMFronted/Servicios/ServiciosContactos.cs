
namespace CRMFronted.Servicios
{
    public class ServiciosContactos : IServiciosContactos
    {
        public Task<HttpResponseWrapper<object>> DeleteContactos(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> DeleteContactos<T, TActionResponse>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<T>> GetContactos<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PostContactos<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostContactos<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PutContactos<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PutContactos<T, TActionResponse>(string url, object model)
        {
            throw new NotImplementedException();
        }
    }
}
