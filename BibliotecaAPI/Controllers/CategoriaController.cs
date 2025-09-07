using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize] // solicita token, para todo el controlador en general
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Categoria>>> ListaCategoria()
        {
            // Generando listado de categorias
            var categorias = await _context.Categorias.ToListAsync();

            return Ok(categorias);
        }
        
        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerCategoria(int id)
        {
            // Buscando la categoria por el id proporcionado
            Categoria? categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return NotFound("Registro no existe.");

            return Ok(categoria);
        }

        [Authorize] // haciendo que este metodo necesite que el usuario este logeado
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearCategoria(Categoria categoria)
        {
            // agregando los datos para el nuevo registro y guardado
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize] // haciendo que este metodo necesite que el usuario este logeado
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            // Buscando el registro por el id proporcionado y validar que exista antes de actualizar
            var categoriaExistente = await _context.Categorias.FindAsync(id);

            if (categoriaExistente == null)
                return NotFound("El Registro no existe!.");

            categoriaExistente.Nombre = categoria.Nombre;
            categoriaExistente.Descripcion = categoria.Descripcion;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize] // haciendo que este metodo necesite que el usuario este logeado
        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            // Buscando el registro por el id y validar si existe, antes de eliminar
            var categoriaDel = await _context.Categorias.FindAsync(id);

            if (categoriaDel == null)
                return NotFound("El Registro que desea Eliminar no Existe.");

            _context.Categorias.Remove(categoriaDel);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
