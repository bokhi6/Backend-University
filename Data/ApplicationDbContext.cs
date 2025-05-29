using Microsoft.EntityFrameworkCore;
using Api_University.Models;
using System;

namespace Api_University.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<EstudianteMateriaProfesor> EstudianteMateriaProfesores { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relaciones
            modelBuilder.Entity<Materia>()
                .HasOne(m => m.Profesor)
                .WithMany(p => p.Materias)
                .HasForeignKey(m => m.ProfesorId);
                
            modelBuilder.Entity<EstudianteMateriaProfesor>()
                .HasOne(emp => emp.Estudiante)
                .WithMany(e => e.EstudianteMateriaProfesores)
                .HasForeignKey(emp => emp.EstudianteId);
                
            modelBuilder.Entity<EstudianteMateriaProfesor>()
                .HasOne(emp => emp.Materia)
                .WithMany(m => m.EstudianteMateriaProfesores)
                .HasForeignKey(emp => emp.MateriaId);
                
            modelBuilder.Entity<EstudianteMateriaProfesor>()
                .HasOne(emp => emp.Profesor)
                .WithMany()
                .HasForeignKey(emp => emp.ProfesorId);
            
            // Datos iniciales
            SeedData(modelBuilder);
        }
        
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Profesores
            modelBuilder.Entity<Profesor>().HasData(
                new Profesor { Id = 1, Nombre = "Dr. García" },
                new Profesor { Id = 2, Nombre = "Dra. López" },
                new Profesor { Id = 3, Nombre = "Dr. Martínez" },
                new Profesor { Id = 4, Nombre = "Dra. Rodríguez" },
                new Profesor { Id = 5, Nombre = "Dr. González" }
            );
            
            // Materias (2 por profesor)
            modelBuilder.Entity<Materia>().HasData(
                new Materia { Id = 1, Nombre = "Matemáticas I", Creditos = 3, ProfesorId = 1 },
                new Materia { Id = 2, Nombre = "Física I", Creditos = 3, ProfesorId = 1 },
                new Materia { Id = 3, Nombre = "Química I", Creditos = 3, ProfesorId = 2 },
                new Materia { Id = 4, Nombre = "Biología I", Creditos = 3, ProfesorId = 2 },
                new Materia { Id = 5, Nombre = "Historia", Creditos = 3, ProfesorId = 3 },
                new Materia { Id = 6, Nombre = "Literatura", Creditos = 3, ProfesorId = 3 },
                new Materia { Id = 7, Nombre = "Inglés I", Creditos = 3, ProfesorId = 4 },
                new Materia { Id = 8, Nombre = "Francés I", Creditos = 3, ProfesorId = 4 },
                new Materia { Id = 9, Nombre = "Filosofía", Creditos = 3, ProfesorId = 5 },
                new Materia { Id = 10, Nombre = "Ética", Creditos = 3, ProfesorId = 5 }
            );

            // Estudiantes de ejemplo
            modelBuilder.Entity<Estudiante>().HasData(
                new Estudiante { Id = 1, Nombre = "Juan Pérez", Email = "juan@email.com", FechaRegistro = DateTime.Parse("2024-01-15") },
                new Estudiante { Id = 2, Nombre = "María González", Email = "maria@email.com", FechaRegistro = DateTime.Parse("2024-01-16") },
                new Estudiante { Id = 3, Nombre = "Carlos Rodríguez", Email = "carlos@email.com", FechaRegistro = DateTime.Parse("2024-01-17") }
            );

            // Inscripciones de estudiantes (respetando la regla de no tener clases con el mismo profesor)
            modelBuilder.Entity<EstudianteMateriaProfesor>().HasData(
                // Juan Pérez: Matemáticas I (Prof. García), Química I (Prof. López), Historia (Prof. Martínez)
                new EstudianteMateriaProfesor { Id = 1, EstudianteId = 1, MateriaId = 1, ProfesorId = 1 },
                new EstudianteMateriaProfesor { Id = 2, EstudianteId = 1, MateriaId = 3, ProfesorId = 2 },
                new EstudianteMateriaProfesor { Id = 3, EstudianteId = 1, MateriaId = 5, ProfesorId = 3 },

                // María González: Física I (Prof. García), Biología I (Prof. López), Inglés I (Prof. Rodríguez)
                new EstudianteMateriaProfesor { Id = 4, EstudianteId = 2, MateriaId = 2, ProfesorId = 1 },
                new EstudianteMateriaProfesor { Id = 5, EstudianteId = 2, MateriaId = 4, ProfesorId = 2 },
                new EstudianteMateriaProfesor { Id = 6, EstudianteId = 2, MateriaId = 7, ProfesorId = 4 },

                // Carlos Rodríguez: Literatura (Prof. Martínez), Francés I (Prof. Rodríguez), Filosofía (Prof. González)
                new EstudianteMateriaProfesor { Id = 7, EstudianteId = 3, MateriaId = 6, ProfesorId = 3 },
                new EstudianteMateriaProfesor { Id = 8, EstudianteId = 3, MateriaId = 8, ProfesorId = 4 },
                new EstudianteMateriaProfesor { Id = 9, EstudianteId = 3, MateriaId = 9, ProfesorId = 5 }
            );
        }
    }
}