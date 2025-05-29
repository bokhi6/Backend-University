using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_mvc_api.Data;
using my_mvc_api.Models;

namespace my_mvc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfesoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/profesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
        {
            return await _context.Profesores
                .Include(p => p.Materias)
                .ToListAsync();
        }

        // GET: api/profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            var profesor = await _context.Profesores
                .Include(p => p.Materias)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }
    }
}