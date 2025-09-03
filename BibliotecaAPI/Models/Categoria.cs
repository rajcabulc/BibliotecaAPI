using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string? Descripcion { get; set; }
    }
}
