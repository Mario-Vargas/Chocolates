using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chocolates.Models;

namespace Chocolates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolatesController : Controller
    {
        private readonly DbChocolatesContext _context;

        public ChocolatesController(DbChocolatesContext context)
        {
            _context = context;
        }

        // GET: Chocolates

        [HttpGet]
        [Route("listaChocolates")]
        //Lista de chocolates incluyendo la categoría a la que pertenecen
        public async Task<IActionResult> GetChocolates()
        {
            var chocolates = await _context.Chocolates.Include(c => c.Categoria).ToListAsync();
            return Ok(chocolates);
        }

        [HttpPost]
        [Route("agregarChocolate")]
        public async Task<IActionResult> PostChocolate([FromBody] Chocolate chocolate)
        {
            if (chocolate == null)
            {
                return BadRequest("Chocolate data is null.");
            }

            // Validar que el chocolate tiene una categoría asignada
            if (chocolate.IdCategoria <= 0)
            {
                return BadRequest("Chocolate must have a valid category.");
            }

            // Comprobar si la categoría existe en la base de datos
            var categoria = await _context.Categorias.FindAsync(chocolate.IdCategoria);
            if (categoria == null)
            {
                return BadRequest("Category does not exist.");
            }

            _context.Chocolates.Add(chocolate);
            await _context.SaveChangesAsync();
            return Ok(chocolate);
        }

        // PUT: api/Chocolates/5
        [HttpPut]
        [Route("actualizarChocolate/{id:int}")]
        public async Task<IActionResult> PutChocolate(int id, [FromBody] Chocolate chocolate)
        {
            if (id != chocolate.IdChocolate)
            {
                return BadRequest();
            }

            _context.Entry(chocolate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChocolateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Chocolates/5
        [HttpDelete]
        [Route("eliminarChocolate/{id:int}")]
        public async Task<IActionResult> DeleteChocolate(int id)
        {
            var chocolate = await _context.Chocolates.FindAsync(id);
            if (chocolate == null)
            {
                return NotFound();
            }

            _context.Chocolates.Remove(chocolate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("obtenerChocolate/{id}")]
        //Obtener un chocolate por su id y retornar la categoría a la que pertenece
        public async Task<IActionResult> GetChocolate(int id)
        {
            var chocolate = await _context.Chocolates.Include(c => c.Categoria).FirstOrDefaultAsync(c => c.IdChocolate == id);

            if (chocolate == null)
            {
                return NotFound();
            }

            return Ok(chocolate);
        }

        private bool ChocolateExists(int id)
        {
            return _context.Chocolates.Any(e => e.IdChocolate == id);
        }
    }
}
