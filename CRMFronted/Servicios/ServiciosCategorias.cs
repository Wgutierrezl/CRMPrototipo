
namespace CRMFronted.Servicios
{
    public class ServiciosCategorias : IServiciosCategorias
    {
        public Task<HttpResponseWrapper<object>> DeleteCategorias(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> DeleteCategorias<T, TActionResponse>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<T>> GetCategorias<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PostCategorias<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostCategorias<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PutCategorias<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PutCategorias<T, TActionResponse>(string url, object model)
        {
            throw new NotImplementedException();
        }
    }
}
