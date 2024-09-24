namespace SuperOferta.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string ProductoName { get; set; }
        public DateOnly FechaCaducidad { get; set; }
    }
}
