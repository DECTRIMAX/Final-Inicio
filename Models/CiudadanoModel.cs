using System.ComponentModel.DataAnnotations;

namespace Final_Inicio.Models
{
    public class CiudadanoModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string TipoAcceso { get; set; } = string.Empty;

        // Propiedades calculadas
        public string NombreCompleto => $"{Nombre} {PrimerApellido} {SegundoApellido}".Trim();
        public string FechaRegistroFormateada => FechaRegistro.ToString("dd/MM/yyyy HH:mm");
    }
}