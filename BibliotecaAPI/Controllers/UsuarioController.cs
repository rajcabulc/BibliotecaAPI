using BibliotecaAPI.Models;
using BibliotecaAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    //[AllowAnonymous] // para acceder sin necesidad de iniciar sesion
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly Utilidades _utilidades;
        public UsuarioController(DataContext context, Utilidades utilidades)
        {
            _context = context;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            // buscar al usuario equivalente con el correo y clave
            var usuarioEncontrado = await _context.Usuarios.
                Where(u => u.Correo == loginDTO.Correo && u.Clave == _utilidades.EncriptarClave(loginDTO.Clave)).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" }); // datos incorrectos y devolver token vacio
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.genJwt(usuarioEncontrado) }); // datos correctos y generar el token
        }
    }
}
