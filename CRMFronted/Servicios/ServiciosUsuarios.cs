
namespace CRMFronted.Servicios
{
    public class ServiciosUsuarios : IServiciosUsuarios
    {
        public Task<HttpResponseWrapper<object>> DeleteUsuarios(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> DeleteUsuarios<T, TActionResponse>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<T>> GetUsuarios<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PostUsuarios<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostUsuarios<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PutUsuarios<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PutUsuarios<T, TActionResponse>(string url, object model)
        {
            throw new NotImplementedException();
        }
    }
}
