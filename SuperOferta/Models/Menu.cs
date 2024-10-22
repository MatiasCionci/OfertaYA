namespace SuperOferta.Models
{
    public class Menu
    {
        public string? Titulo1 { get; set; }
        public string? Titulo2 { get; set; }

        public string? Titulo6 { get; set; }

        public Menu(String titulo,string second, string? titulo6)
        {
            Titulo1 = titulo; Titulo2 = second;
            Titulo6 = titulo6;
        }
    }
}
