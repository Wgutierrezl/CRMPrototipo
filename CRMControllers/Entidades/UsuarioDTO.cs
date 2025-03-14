using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    public class UsuarioDTO
    {
        public string? UsuarioID { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? Rol { get; set; }
        public string? Estado { get; set; }

    }
}
