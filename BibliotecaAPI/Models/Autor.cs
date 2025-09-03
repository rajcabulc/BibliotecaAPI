using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string Nombre { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")] //"{0:yyyy/MM/dd hh:mm tt}"
        public DateTime FechaNacimiento { get; set; }
    }
}
