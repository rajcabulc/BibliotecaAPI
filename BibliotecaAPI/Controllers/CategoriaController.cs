using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public CategoriaController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Categoria>>> ListaCategoria()
        {
            var categorias = await _context.Categorias.ToListAsync();

            return Ok(categorias);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerCategoria(int id)
        {
            Categoria categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return NotFound("Registro no existe.");

            return Ok(categoria);
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearCategoria(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            var categoriaExistente = await _context.Categorias.FindAsync(id);

            if (categoriaExistente == null)
                return NotFound("El Registro no existe!.");

            categoriaExistente.Nombre = categoria.Nombre;
            categoriaExistente.Descripcion = categoria.Descripcion;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            string token = Request.Headers.Where(x => x.Key == "tokenDel").FirstOrDefault().Value;
            if (token != "seitin$123")
                return BadRequest("Token Incorrecto.");

            var categoriaDel = await _context.Categorias.FindAsync(id);

            if (categoriaDel == null)
                return NotFound("El Registro que desea Eliminar no Existe.");

            _context.Categorias.Remove(categoriaDel);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
