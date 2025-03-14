using CRMBackend.Data;
using CRMBackend.Custom;
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
using System.Runtime.CompilerServices;
using NuGet.Common;

namespace CRMBackend.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly Utilidades _utilidades;

        public UserController(DataContext context,Utilidades utilidades)
        {
            _context = context;
            _utilidades = utilidades;
        }


        [HttpPost("/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _context.Usuarios.Where(e => e.Correo == login.Email && e.Contraseña == _utilidades.EncryptSHA256(login.Clave!)).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { IsSuccess = false, Token = "" });
            }
            else
            {
                return Ok(new SesionDTO
                {
                    UsuarioID = usuario.IDUsuario,
                    Nombre = usuario.Nombre,
                    Correo = usuario.Correo,
                    Rol = usuario.Rol,
                    Token = _utilidades.GenerateJWT(usuario)
                });
            }

        }


        [HttpPost]
        [Route("Registrarse")]
        public async Task<ActionResult<Usuarios>> Registrarse(UsuarioDTO user)
        {
            var UserCreated = new Usuarios
            {
                IDUsuario = user.UsuarioID,
                Nombre = user.Nombre,
                Correo = user.Correo,
                Contraseña = _utilidades.EncryptSHA256(user.Contraseña!),
                Rol = user.Rol,
                Estado = user.Estado!

            };


            await _context.Usuarios.AddAsync(UserCreated);
            await _context.SaveChangesAsync();

            if (UserCreated.IDUsuario != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { IsSuccess = true });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { IsSuccess = false });
            }
        }


    }


}
