using Microsoft.AspNetCore.Identity;

namespace SuperOferta.Models
{
	public class MyRol:IdentityRole
	{
		public string seccion {  get; set; }
	}
}
