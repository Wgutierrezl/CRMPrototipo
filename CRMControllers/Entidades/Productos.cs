using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMControllers.Entidades
{
    public class Productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoID { get; set; }

        [Required]
        public int IDCategoria { get; set; }

        [Required]
        [StringLength(125)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string? Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

    }
}
