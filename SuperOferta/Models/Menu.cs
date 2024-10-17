namespace SuperOferta.Models
{
    public class Menu
    {
        public string? Titulo1 { get; set; }
        public string? Titulo2 { get; set; }
        
        public Menu(String titulo,string second)
        {
            Titulo1 = titulo; Titulo2=second;
        }
    }
}
