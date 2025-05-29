
using System.Collections.Generic;

namespace Api_University.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; } = 3;
        public int ProfesorId { get; set; }

        // Navegación
        public Profesor Profesor { get; set; } = null!;
        public List<EstudianteMateriaProfesor> EstudianteMateriaProfesores { get; set; } = new();
    }
}