using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    class Contactos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactoID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string? Apellido { get; set; }

        [Required]
        [StringLength(225)]
        [EmailAddress]
        public string? Correo { get; set; }

        [Required]
        [StringLength(50)]
        public string? Fuente { get; set; }

        [Required]
        [StringLength(50)]
        public string? Estado { get; set; } = "Nuevo"; // Estado por defecto
    }
}
