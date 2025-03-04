using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    public class Usuarios
    {
        [Key]
        public string? IDUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? Rol { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
