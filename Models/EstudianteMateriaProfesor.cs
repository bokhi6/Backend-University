namespace Api_University.Models
{
    public class EstudianteMateriaProfesor
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }
        public int ProfesorId { get; set; }
        
        // Navegación
        public Estudiante Estudiante { get; set; } = null!;
        public Materia Materia { get; set; } = null!;
        public Profesor Profesor { get; set; } = null!;
    }
}