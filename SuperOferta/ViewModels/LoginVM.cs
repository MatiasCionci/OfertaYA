using System.ComponentModel.DataAnnotations;

namespace SuperOferta.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="username requerido")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "password requerido")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name ="Remember")]
        public bool RememberMe { get; set; }
    }
}
