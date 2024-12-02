using System.ComponentModel.DataAnnotations;

namespace SuperOferta.Models
{
    public class Producto
    {
        public int Id { get; set; }
   
        public string? ProductoName { get; set; }
        [Required(ErrorMessage = "La fecha de caducidad es obligatoria.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Producto), nameof(ValidarFechaCaducidad))]
        public DateOnly? FechaCaducidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public int? Precio { get; set; }
        public string? Descripcion { get; set; }

        public String? categoria {  get; set; }

        public string? imagen {  get; set; }


        public static ValidationResult ValidarFechaCaducidad(DateOnly fechaCaducidad, ValidationContext context)
        {
            if (fechaCaducidad <= DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult("La fecha de caducidad debe ser posterior a la fecha actual.");
            }
            return ValidationResult.Success;
        }

    }
}
