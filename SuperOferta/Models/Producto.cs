namespace SuperOferta.Models
{
    public class Producto
    {
        public int Id { get; set; }
   
        public string? ProductoName { get; set; }
        public DateOnly? FechaCaducidad { get; set; }

        public int? Precio { get; set; }
        public string? Descripcion { get; set; }

        public String? categoria {  get; set; }

        public string? imagen {  get; set; }


    }
}
