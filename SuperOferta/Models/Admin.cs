namespace SuperOferta.Models
{
    public class Admin
    {
        private int Id { get; set; }
        private string? Username {  get; set; }
        private List<NotificacionesAdmin>? Notificaciones=new List<NotificacionesAdmin>();
    }
}
