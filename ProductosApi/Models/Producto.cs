using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosApi.Models
{
    public class Producto
    {
        public int Id { get; set; } // Identificador único del producto

        [Required, MinLength(3)] // Nombre obligatorio con mínimo 3 caracteres
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; } // Descripción opcional

        [Column(TypeName = "decimal(18,2)")] // Define el tipo de dato en la BD
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")] // precio mínimo
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")] // Evita que el stock sea negativo
        public int Stock { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Genera la fecha de creacion 
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
