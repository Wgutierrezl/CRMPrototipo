using Blazored.SessionStorage;
using CRMControllers.Entidades;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
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
                Console.WriteLine($"UsuarioID: {sesionusuario.UsuarioID}");
                Console.WriteLine($"Nombre: {sesionusuario.Nombre}");
                Console.WriteLine($"Correo: {sesionusuario.Correo}");
                Console.WriteLine($"Rol: {sesionusuario.Rol}");
                Console.WriteLine($"Token: {sesionusuario.Token}");// 👈 Verifica que tiene valor

                claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                        new Claim("UsuarioID", sesionusuario.UsuarioID),
                        new Claim("Nombre", sesionusuario.Nombre),
                        new Claim("Email", sesionusuario.Correo),
                        new Claim(ClaimTypes.Role, sesionusuario.Rol),
                        new Claim("Token", sesionusuario.Token)
                }, "JwtAuth"));

                await _sessionStorageService.GuardarStorage("sesionUsuario", sesionusuario);
                await _sessionStorageService.GuardarStorage("authToken", sesionusuario.Token);

            }
            else
            {
                claimsprincipal = _sininformacion;
                await _sessionStorageService.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsprincipal)));
        }

        //public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionusuario)
        //{
        //    ClaimsPrincipal claimsPrincipal;
        //    if (sesionusuario != null)
        //    {
        //        // Decodificar el token JWT
        //        var handler = new JwtSecurityTokenHandler();
        //        var jwtToken = handler.ReadJwtToken(sesionusuario.Token);

        //        // Extraer los claims directamente del token
        //        var claims = jwtToken.Claims.ToList();

        //        // (Opcional) Agregar o transformar algún claim si lo requieres
        //        // Por ejemplo, para asegurarte de que el rol esté en el formato correcto:
        //        // claims.Add(new Claim(ClaimTypes.Role, sesionusuario.Rol));

        //        claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

        //        await _sessionStorageService.GuardarStorage("sesionUsuario", sesionusuario);
        //        await _sessionStorageService.GuardarStorage("authToken", sesionusuario.Token);
        //    }
        //    else
        //    {
        //        claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        //        await _sessionStorageService.RemoveItemAsync("sesionUsuario");
        //    }

        //    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        //}

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
                new Claim("Nombre",usuario.Nombre),
                new Claim("Email",usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Rol),
                new Claim("Token",usuario.Token)

            },"JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsprincipal));
        }
    }
}
