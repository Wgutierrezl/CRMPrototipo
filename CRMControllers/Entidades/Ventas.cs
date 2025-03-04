using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    public class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VentaID { get; set; }

        [Required]
        public int IDCliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaVenta { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; } = "Pendiente";
    }
}
