using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace my_mvc_api.Migrations
{
    /// <inheritdoc />
    public partial class AddEstudiantesEjemplo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "Email", "FechaRegistro", "Nombre" },
                values: new object[,]
                {
                    { 1, "juan@email.com", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Pérez" },
                    { 2, "maria@email.com", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "María González" },
                    { 3, "carlos@email.com", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Rodríguez" }
                });

            migrationBuilder.InsertData(
                table: "EstudianteMateriaProfesores",
                columns: new[] { "Id", "EstudianteId", "MateriaId", "ProfesorId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 3, 2 },
                    { 3, 1, 5, 3 },
                    { 4, 2, 2, 1 },
                    { 5, 2, 4, 2 },
                    { 6, 2, 7, 4 },
                    { 7, 3, 6, 3 },
                    { 8, 3, 8, 4 },
                    { 9, 3, 9, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EstudianteMateriaProfesores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
