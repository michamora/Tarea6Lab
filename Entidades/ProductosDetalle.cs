using System.ComponentModel.DataAnnotations;

namespace Tarea6Lab.Models
{
    public class ProductosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir la Presentacion")]
        public string Presentacion { get; set; }
        
        [Required(ErrorMessage = "La Cantidad no puede estar vacia...")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe estar en un rango de {1} y {2}.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El Precio no puede estar vacio...")]
        [Range(1, int.MaxValue, ErrorMessage = "El Precio debe estar en un rango de {1} y {2}.")]
        public double Precio { get; set; }

        public ProductosDetalle()
        {
            this.Id = 0;

            this.ProductoId = 0;

            this.Presentacion = "";

            this.Cantidad = 0;

            this.Precio = 0;
        }

        public ProductosDetalle(string presentacion, int cantidad, double precio)
        {
            this.Presentacion = presentacion;

            this.Cantidad = cantidad;
            
            this.Precio = precio;

            
        }

    }
}