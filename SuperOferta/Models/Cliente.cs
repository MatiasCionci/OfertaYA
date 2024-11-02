using Microsoft.AspNetCore.Identity;

namespace SuperOferta.Models
{
    public class Cliente:IdentityUser
    {    public int Id { get; set; }
        public string? Nombre{get; set;}
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }


		

    }
}
