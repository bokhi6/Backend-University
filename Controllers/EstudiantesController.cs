using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_University.Data;
using Api_University.Models;
using Api_University.Models.DTOs;

namespace Api_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteResponseDto>>> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiantes
                .Include(e => e.EstudianteMateriaProfesores)
                    .ThenInclude(emp => emp.Materia)
                .Include(e => e.EstudianteMateriaProfesores)
                    .ThenInclude(emp => emp.Profesor)
                .ToListAsync();

            var result = estudiantes.Select(e => new EstudianteResponseDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Email = e.Email,
                FechaRegistro = e.FechaRegistro,
                Materias = e.EstudianteMateriaProfesores.Select(emp => new MateriaConProfesorDto
                {
                    MateriaId = emp.MateriaId,
                    MateriaNombre = emp.Materia.Nombre,
                    Creditos = emp.Materia.Creditos,
                    ProfesorId = emp.ProfesorId,
                    ProfesorNombre = emp.Profesor.Nombre
                }).ToList()
            }).ToList();

            return Ok(result);
        }

        // GET: api/estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteResponseDto>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes
                .Include(e => e.EstudianteMateriaProfesores)
                    .ThenInclude(emp => emp.Materia)
                .Include(e => e.EstudianteMateriaProfesores)
                    .ThenInclude(emp => emp.Profesor)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }

            var result = new EstudianteResponseDto
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Email = estudiante.Email,
                FechaRegistro = estudiante.FechaRegistro,
                Materias = estudiante.EstudianteMateriaProfesores.Select(emp => new MateriaConProfesorDto
                {
                    MateriaId = emp.MateriaId,
                    MateriaNombre = emp.Materia.Nombre,
                    Creditos = emp.Materia.Creditos,
                    ProfesorId = emp.ProfesorId,
                    ProfesorNombre = emp.Profesor.Nombre
                }).ToList()
            };

            return Ok(result);
        }

        // POST: api/estudiantes
        [HttpPost]
        public async Task<ActionResult<EstudianteResponseDto>> PostEstudiante(EstudianteDto estudianteDto)
        {
            // Validar que solo seleccione 3 materias
            if (estudianteDto.MateriaIds.Count != 3)
            {
                return BadRequest("El estudiante debe seleccionar exactamente 3 materias.");
            }

            // Validar que las materias existan
            var materias = await _context.Materias
                .Include(m => m.Profesor)
                .Where(m => estudianteDto.MateriaIds.Contains(m.Id))
                .ToListAsync();

            if (materias.Count != 3)
            {
                return BadRequest("Una o más materias seleccionadas no existen.");
            }

            // Validar que no tenga clases con el mismo profesor
            var profesorIds = materias.Select(m => m.ProfesorId).ToList();
            if (profesorIds.Distinct().Count() != profesorIds.Count)
            {
                return BadRequest("No puedes tener clases con el mismo profesor.");
            }

            // Crear el estudiante
            var estudiante = new Estudiante
            {
                Nombre = estudianteDto.Nombre,
                Email = estudianteDto.Email,
                FechaRegistro = DateTime.Now
            };

            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            // Crear las relaciones estudiante-materia-profesor
            foreach (var materia in materias)
            {
                var emp = new EstudianteMateriaProfesor
                {
                    EstudianteId = estudiante.Id,
                    MateriaId = materia.Id,
                    ProfesorId = materia.ProfesorId
                };
                _context.EstudianteMateriaProfesores.Add(emp);
            }

            await _context.SaveChangesAsync();

            // Retornar el estudiante creado
            var result = new EstudianteResponseDto
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Email = estudiante.Email,
                FechaRegistro = estudiante.FechaRegistro,
                Materias = materias.Select(m => new MateriaConProfesorDto
                {
                    MateriaId = m.Id,
                    MateriaNombre = m.Nombre,
                    Creditos = m.Creditos,
                    ProfesorId = m.ProfesorId,
                    ProfesorNombre = m.Profesor.Nombre
                }).ToList()
            };

            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Id }, result);
        }

        // GET: api/estudiantes/5/companeros
        [HttpGet("{id}/companeros")]
        public async Task<ActionResult<IEnumerable<CompañerosClaseDto>>> GetCompañerosClase(int id)
        {
            var estudiante = await _context.Estudiantes
                .Include(e => e.EstudianteMateriaProfesores)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }

            var materiaIds = estudiante.EstudianteMateriaProfesores.Select(emp => emp.MateriaId).ToList();

            var companeros = new List<CompañerosClaseDto>();

            foreach (var materiaId in materiaIds)
            {
                var materia = await _context.Materias.FindAsync(materiaId);
                var estudiantesEnMateria = await _context.EstudianteMateriaProfesores
                    .Include(emp => emp.Estudiante)
                    .Where(emp => emp.MateriaId == materiaId && emp.EstudianteId != id)
                    .Select(emp => emp.Estudiante.Nombre)
                    .ToListAsync();

                companeros.Add(new CompañerosClaseDto
                {
                    MateriaId = materiaId,
                    MateriaNombre = materia?.Nombre ?? "",
                    NombresCompañeros = estudiantesEnMateria
                });
            }

            return Ok(companeros);
        }
    }
}