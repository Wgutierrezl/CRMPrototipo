using Microsoft.AspNetCore.Components.Authorization;

namespace CRMFronted.Extensiones
{
    public class AuthService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<string?> ObtenerRolUsuario()
        {
            var user = (await _authStateProvider.GetAuthenticationStateAsync()).User;
            return user.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        }
    }
}
