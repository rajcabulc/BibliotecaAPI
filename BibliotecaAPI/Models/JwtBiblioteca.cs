using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BibliotecaAPI.Models
{
    public class JwtBiblioteca
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        //
        private readonly DataContext _context;

        public JwtBiblioteca(DataContext context)
        {
            _context = context;
        }

        // Validar Token
        public async Task<dynamic> validarToken(ClaimsIdentity identity)
        {
            try
            {
                if(identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Verifique si estas enviando un token valido",
                        result = ""
                    };
                }

                var id = int.Parse(identity.Claims.FirstOrDefault(x => x.Type == "id").Value);

                Usuario usuario = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();

                return new
                {
                    success = true,
                    message = "Exito",
                    result = usuario
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Error: " + ex.Message,
                    result = ""
                };
            }
        }
    }
}
