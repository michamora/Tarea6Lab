using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea6Lab.Models
{
    public class Productos
    {
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "La existencia debe estar en un rango de {1} y {2}.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Descripcion { get; set; }
        
        
        [Required(ErrorMessage ="Campo obligatorio. poner fecha de vencimiento.")]
        public DateTime FechaVencimiento { get; set; }
        
        [Required(ErrorMessage = "La Existencia no puede estar vacio...")]
        [Range(1, int.MaxValue, ErrorMessage = "La existencia debe estar en el rango de {1} y {2}.")]
        public int Existencia { get; set; }
        
        [Required(ErrorMessage = "El Costo no puede estar vacio...")]
        [Range(1, double.MaxValue, ErrorMessage = "El Costo debe estar en un rango de {1} y {2}.")]
        public double Costo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar el precio.")]
        [Range(1, double.MaxValue, ErrorMessage = "Se debe indicar el precio del producto dentro de los rangos {1}/{2}.")]
        public double Precio { get; set; }

        public int Ganancia { get; set; }
        public double ValorInventario { get; set; }
        public DateTime Fecha { get; set; }

        

        [ForeignKey("ProductoId")]
        public List<ProductosDetalle> Detalle { get; set; } = new List<ProductosDetalle> ();

    
    }
}