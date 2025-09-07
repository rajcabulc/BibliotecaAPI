using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string NombreUsuario { get; set; } = null!;
        public string? URLFotoPerfil { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;
    }
}
