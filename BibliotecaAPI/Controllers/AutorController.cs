using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly DataContext _context;

        public AutorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Autor>>> ListaAutor()
        {
            // Generando listado
            var autores = await _context.Autores.ToListAsync();

            return Ok(autores);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerAutor(int id)
        {
            // Buscando el registro por el id
            Autor? autores = await _context.Autores.FindAsync(id);

            if (autores == null)
                return NotFound("El Registro no existe.");

            return Ok(autores);
        }

        [Authorize] // haciendo que este metodo necesite que el usuario este logeado
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult>CrearAutor(Autor autor)
        {
            // agregando datos para el nuevo registro y guardando
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize] // haciendo que este metodo necesite que el usuario este logeado
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarAutor(int id, Autor autor)
        {
            // buscando el registro y validando que exista antes de actualizar
            var autorExistente = await _context.Autores.FindAsync(id);

            if (autorExistente == null)
                return NotFound("Registro no existe.");

            autorExistente!.Nombre = autor.Nombre;
            autorExistente.FechaNacimiento = autor.FechaNacimiento;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize] // haciendo que este metodo necesite que el usuario este logeado
        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            // buscando el registro y validando que exista antes de eliminar
            var autorDel = await _context.Autores.FindAsync(id);

            if (autorDel == null)
                return NotFound("El Registro que desea Eliminar no Existe.");

            _context.Autores.Remove(autorDel!);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
