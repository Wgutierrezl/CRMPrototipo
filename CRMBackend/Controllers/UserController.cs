using CRMBackend.Data;
using CRMControllers.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace CRMBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuracion;

        public UserController(DataContext context,IConfiguration configuracion)
        {
            _context = context;
            _configuracion = configuracion;
        }


        [HttpPost("/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _context.Usuarios.Where(e => e.Correo == login.Email && e.Contraseña == login.Clave).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "correo o contraseñas incorrectas" });
            }

            var token = GenerarToken(usuario);

            return Ok(new SesionDTO
            {
                UsuarioID = usuario.IDUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol,
                Token = token
            });

        }

        private string GenerarToken(Usuarios usuarios)
        {
            var jwtsetting = _configuracion.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtsetting["SecretKey"]);

            var claims = new List<Claim>
            {
                new Claim("UsuarioID",usuarios.IDUsuario),
                new Claim(ClaimTypes.Name,usuarios.Nombre),
                new Claim(ClaimTypes.Email,usuarios.Correo),
                new Claim(ClaimTypes.Role,usuarios.Rol)
            };

            var key = new SymmetricSecurityKey(secretKey);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtsetting["Issuer"],
                audience: jwtsetting["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
