
namespace CRMFronted.Servicios
{
    public class ServiciosVentas : IServiciosVentas
    {
        public Task<HttpResponseWrapper<object>> DeleteVentas(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> DeleteVentas<T, TActionResponse>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<T>> GetVentas<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PostVentas<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostVentas<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PutVentas<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PutVentas<T, TActionResponse>(string url, object model)
        {
            throw new NotImplementedException();
        }
    }
}
