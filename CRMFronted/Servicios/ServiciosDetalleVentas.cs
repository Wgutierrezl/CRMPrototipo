
namespace CRMFronted.Servicios
{
    public class ServiciosDetalleVentas : IServiciosDetalleVenta
    {
        public Task<HttpResponseWrapper<object>> DeleteDetalleVenta(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> DeleteDetalleVenta<T, TActionResponse>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<T>> GetDetalleVenta<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PostDetalleVenta<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostDetalleVenta<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PutDetalleVenta<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PutDetalleVenta<T, TActionResponse>(string url, object model)
        {
            throw new NotImplementedException();
        }
    }
}
