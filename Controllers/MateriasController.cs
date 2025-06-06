using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_University.Data;
using Api_University.Models;

namespace Api_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMaterias()
        {
            return await _context.Materias
                .Include(m => m.Profesor)
                .ToListAsync();
        }

        // GET: api/materias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await _context.Materias
                .Include(m => m.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }
    }
}