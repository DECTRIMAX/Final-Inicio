namespace Final_Inicio.Models
{
    public class DashboardViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public DateTime FechaAcceso { get; set; } = DateTime.Now;

        // Datos específicos del ciudadano
        public CiudadanoModel? CiudadanoData { get; set; }

        // Propiedades para la vista
        public string FechaAccesoFormateada => FechaAcceso.ToString("dd/MM/yyyy HH:mm");
        public bool EsCiudadano => UserRole == "Ciudadano";
        public bool TieneDatosCiudadano => CiudadanoData != null;
    }
}