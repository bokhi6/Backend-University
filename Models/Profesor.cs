using System.Collections.Generic;

namespace Api_University.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public List<Materia> Materias { get; set; } = new();
    }
}