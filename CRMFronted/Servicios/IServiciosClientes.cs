namespace CRMFronted.Servicios
{
    public interface IServiciosClientes
    {
        Task<HttpResponseWrapper<T>> GetClientes<T>(string url);
        Task<HttpResponseWrapper<object>> PostClientes<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostClientes<T,TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutClientes<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutClientes<T,TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteClientes(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteClientes<T,TActionResponse>(string url);

    }

    public interface IServiciosProductos
    {
        Task<HttpResponseWrapper<T>> GetProductos<T>(string url);
        Task<HttpResponseWrapper<object>> PostProductos<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostProductos<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutProductos<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutProductos<T, TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteProductos(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteProductos<T, TActionResponse>(string url);
    }

    public interface IServiciosCategorias
    {
        Task<HttpResponseWrapper<T>> GetCategorias<T>(string url);
        Task<HttpResponseWrapper<object>> PostCategorias<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostCategorias<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutCategorias<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutCategorias<T, TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteCategorias(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteCategorias<T, TActionResponse>(string url);

    }

    public interface IServiciosContactos
    {
        Task<HttpResponseWrapper<T>> GetContactos<T>(string url);
        Task<HttpResponseWrapper<object>> PostContactos<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostContactos<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutContactos<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutContactos<T, TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteContactos(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteContactos<T, TActionResponse>(string url);
    }

    public interface IServiciosDetalleVenta
    {
        Task<HttpResponseWrapper<T>> GetDetalleVenta<T>(string url);
        Task<HttpResponseWrapper<object>> PostDetalleVenta<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostDetalleVenta<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutDetalleVenta<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutDetalleVenta<T, TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteDetalleVenta(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteDetalleVenta<T, TActionResponse>(string url);

    }

    public interface IServiciosOportunidadVenta
    {
        Task<HttpResponseWrapper<T>> GetOportunidadVenta<T>(string url);
        Task<HttpResponseWrapper<object>> PostOportunidadVenta<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostOportunidadVenta<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutOportunidadVenta<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutOportunidadVenta<T, TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteOportunidadVenta(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteOportunidadVenta<T, TActionResponse>(string url);
    }

    public interface IServiciosUsuarios
    {
        Task<HttpResponseWrapper<T>> GetUsuarios<T>(string url);
        Task<HttpResponseWrapper<object>> PostUsuarios<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostUsuarios<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutUsuarios<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutUsuarios<T, TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteUsuarios(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteUsuarios<T, TActionResponse>(string url);
    }

    public interface IServiciosVentas
    {
        Task<HttpResponseWrapper<T>> GetVentas<T>(string url);
        Task<HttpResponseWrapper<object>> PostVentas<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostVentas<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutVentas<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutVentas<T, TActionResponse>(string url, object model);
        Task<HttpResponseWrapper<object>> DeleteVentas(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteVentas<T, TActionResponse>(string url);
    }
}
