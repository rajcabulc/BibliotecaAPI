using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public AutorController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Autor>>> ListaAutor()
        {
            var autores = await _context.Autores.ToListAsync();

            return Ok(autores);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerAutor(int id)
        {
            Autor autores = await _context.Autores.FindAsync(id);

            if (autores == null)
                return NotFound("El Registro no existe.");

            return Ok(autores);
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult>CrearAutor(Autor autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarAutor(int id, Autor autor)
        {
            var autorExistente = await _context.Autores.FindAsync(id);

            if (autorExistente == null)
                return NotFound("Registro no existe.");

            autorExistente!.Nombre = autor.Nombre;
            autorExistente.FechaNacimiento = autor.FechaNacimiento;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var autorDel = await _context.Autores.FindAsync(id);

            if (autorDel == null)
                return NotFound("El Registro que desea Eliminar no Existe.");

            _context.Autores.Remove(autorDel!);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
