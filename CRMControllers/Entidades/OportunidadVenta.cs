using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    public class OportunidadVenta
    {
        [Key]
        public int OportunidadID { get; set; }
        public int IDCliente { get; set; }
        public string? Descripcion { get; set; } 
        public decimal ValorEstimado { get; set; }
        public string? Estado { get; set; }
        public DateOnly FechaCierreEsperada { get; set; }
        public DateTime FechaCreacion { get; set; }


    }
}
