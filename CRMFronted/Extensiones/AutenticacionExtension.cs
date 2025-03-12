using Blazored.SessionStorage;
using CRMControllers.Entidades;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CRMFronted.Extensiones
{
    public class AutenticacionExtension:AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal _sininformacion = new ClaimsPrincipal(new ClaimsIdentity());



        public AutenticacionExtension(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionusuario)
        {
            ClaimsPrincipal claimsprincipal;
            if (sesionusuario != null)
            {
                claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim("UsuarioID",sesionusuario.UsuarioID),
                    new Claim(ClaimTypes.Name,sesionusuario.Nombre),
                    new Claim(ClaimTypes.Email,sesionusuario.Correo),
                    new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", sesionusuario.Rol),
                    new Claim("Token",sesionusuario.Token)
                },"JwtAuth"));

                await _sessionStorageService.GuardarStorage("sesionUsuario", sesionusuario);

            }
            else
            {
                claimsprincipal = _sininformacion;
                await _sessionStorageService.RemoveItemAsync("sesionUsuario");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsprincipal)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usuario = await _sessionStorageService.ObtenerStorage<SesionDTO>("sesionusuario");
            if (usuario == null)
            {
                return await Task.FromResult(new AuthenticationState(_sininformacion));
            }

            var claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim("UsuarioID",usuario.UsuarioID),
                new Claim(ClaimTypes.Name,usuario.Nombre),
                new Claim(ClaimTypes.Email,usuario.Correo),
                new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", usuario.Rol),
                new Claim("Token",usuario.Token)

            },"JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsprincipal));
        }
    }
}
