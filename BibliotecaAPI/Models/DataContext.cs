using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        // en estas lineas es para que las clases se conviertan en tablas al momento de migrar
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
