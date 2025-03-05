using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? Empresa { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public string? TipoCliente { get; set; }
    }
}
