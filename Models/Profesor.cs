using System.Collections.Generic;

namespace my_mvc_api.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public List<Materia> Materias { get; set; } = new();
    }
}