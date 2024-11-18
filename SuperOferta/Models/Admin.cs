namespace SuperOferta.Models
{
    public class Admin
    {
        private Guid Id { get; set; }
        private string? Username {  get; set; }
        private List<NotificacionesAdmin>? Notificaciones=new List<NotificacionesAdmin>();
    }
}
