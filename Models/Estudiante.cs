using System;
using System.Collections.Generic;

namespace Api_University.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        
        // Navegación
        public List<EstudianteMateriaProfesor> EstudianteMateriaProfesores { get; set; } = new();
    }
}