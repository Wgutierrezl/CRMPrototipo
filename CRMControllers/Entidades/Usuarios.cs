using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    class Usuarios
    {
        [Key]
        [StringLength(100)]
        public string? IDUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string? Correo { get; set; }

        [Required]
        [StringLength(255)]
        public string? Contraseña { get; set; }

        [Required]
        [StringLength(20)]
        public string? Rol { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Activo";
    }
}
