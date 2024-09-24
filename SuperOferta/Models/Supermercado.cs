using System.Collections;

namespace SuperOferta.Models
{
    public class Supermercado
    {
        public int SupermercadoId { get; set; }
        public string SupermercadoName { get; set; }

        public List<Producto> productos = new();

    }
}
