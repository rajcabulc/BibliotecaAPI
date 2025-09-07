using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Correo { get; set; } = null!;
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Clave { get; set; } = null!;
    }
}
