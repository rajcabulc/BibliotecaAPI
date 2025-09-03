using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models
{
    public class BibliotecaContext:DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) 
        { 
        }

        // en estas lineas es para que las clases se conviertan en tablas al momento de migrar
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
