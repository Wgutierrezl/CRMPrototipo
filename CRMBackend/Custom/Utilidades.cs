using CRMControllers.Entidades;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace CRMBackend.Custom
{
    public class Utilidades
    {
        private readonly IConfiguration _iconfiguration;
        public Utilidades(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            
        }

        public string EncryptSHA256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string GenerateJWT(Usuarios modelo)
        {
            var userclaim = new[]
            {
                new Claim("UsuarioID",modelo.IDUsuario.ToString()),
                new Claim("Email",modelo.Correo!),
                new Claim(ClaimTypes.Role,modelo.Rol!)

            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var jwtConfig = new JwtSecurityToken(
            issuer: _iconfiguration["jwt:issuer"],  // 👈 Agregar el emisor
            audience: _iconfiguration["jwt:audience"],  // 👈 Agregar la audiencia
            claims: userclaim,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
    );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
