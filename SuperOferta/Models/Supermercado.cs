using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperOferta.Models
{
    public class Supermercado
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? SupermercadoName { get; set; }

        public string? Confirmacion { get; set; } = "SI";

        public string? Direccion { get; set; }

        public string? Correo { get; set; }

        public string? Password { get; set; }

        public string? Coordenadaxx { get; set; }

        public string? Coordenadayy { get; set; }

        public List<Producto>? Productos { get; set; }= new ();
        
      
       
    }
}
