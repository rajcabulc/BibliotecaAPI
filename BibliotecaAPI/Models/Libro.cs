using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de Seleccionar un Autor.")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de Seleccionar una Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }

        [Display(Name = "Imagen")]
        public string? URLImagen { get; set; }
    }
}
