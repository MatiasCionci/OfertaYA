using System.ComponentModel.DataAnnotations;

namespace SuperOferta.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? Nombre {  get; set; }
        public string? Apellido { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Direccion { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [Compare("Password",ErrorMessage ="Los password no son iguales")]
        public string? ConfirmarPassword { get; set; }

        public string? UserName { get; set; }
        

    }
}
