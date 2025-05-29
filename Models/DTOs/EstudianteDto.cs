using System;
using System.Collections.Generic;

namespace Api_University.Models.DTOs
{
    public class EstudianteDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<int> MateriaIds { get; set; } = new();
    }
    
    public class EstudianteResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public List<MateriaConProfesorDto> Materias { get; set; } = new();
    }
    
    public class MateriaConProfesorDto
    {
        public int MateriaId { get; set; }
        public string MateriaNombre { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int ProfesorId { get; set; }
        public string ProfesorNombre { get; set; } = string.Empty;
    }
    
    public class CompañerosClaseDto
    {
        public int MateriaId { get; set; }
        public string MateriaNombre { get; set; } = string.Empty;
        public List<string> NombresCompañeros { get; set; } = new();
    }
}