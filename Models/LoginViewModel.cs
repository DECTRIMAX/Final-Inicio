using System.ComponentModel.DataAnnotations;

namespace Final_Inicio.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Recordarme")]
        public bool RecordarMe { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string? Area { get; set; }
    }
}