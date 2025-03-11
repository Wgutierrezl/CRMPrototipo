using Microsoft.JSInterop;

namespace CRMFronted.Extensiones
{
    public class TokenService
    {
        private readonly IJSRuntime _jsRuntime;

        public TokenService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task GuardarTokenAsync(string token)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "authToken", token);
        }

        public async Task<string> ObtenerTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");
        }

        public async Task EliminarTokenAsync()
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "authToken");
        }
    }
}
