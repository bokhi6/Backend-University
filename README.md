# Api University - Sistema de Registro de Estudiantes

Este proyecto es una API REST desarrollada en .NET 9.0 para la gestión de registro de estudiantes universitarios. Implementa un sistema de créditos académicos con reglas de negocio específicas.

## 📋 Descripción del Proyecto

### Reglas de Negocio
- **10 materias** disponibles (cada una vale 3 créditos)
- **5 profesores** (cada profesor dicta exactamente 2 materias)
- **Estudiantes** deben seleccionar exactamente **3 materias**
- **Restricción clave:** Un estudiante NO puede tener clases con el mismo profesor
- Los estudiantes pueden ver qué compañeros tendrán en cada materia

### Funcionalidades Principales
- ✅ CRUD completo de estudiantes
- ✅ Validación automática de reglas de negocio
- ✅ Consulta de materias y profesores disponibles
- ✅ Sistema para ver compañeros de clase por materia
- ✅ API RESTful con documentación Swagger

## 🏗️ Arquitectura del Proyecto

```
Api-University/
├── Controllers/
│   ├── EstudiantesController.cs    # CRUD y lógica de estudiantes
│   ├── MateriasController.cs       # Gestión de materias
│   ├── ProfesoresController.cs     # Gestión de profesores
│   └── HomeController.cs           # Controlador principal
├── Models/
│   ├── Estudiante.cs               # Entidad estudiante
│   ├── Materia.cs                  # Entidad materia
│   ├── Profesor.cs                 # Entidad profesor
│   ├── EstudianteMateriaProfesor.cs # Relación muchos a muchos
│   └── DTOs/                       # Objetos de transferencia de datos
│       └── EstudianteDto.cs
├── Data/
│   └── ApplicationDbContext.cs     # Contexto de Entity Framework
├── Migrations/                     # Migraciones de base de datos
├── Program.cs                      # Punto de entrada
├── Startup.cs                      # Configuración de servicios
└── appsettings.json               # Configuración de aplicación
```

## 🛠️ Tecnologías Utilizadas

- **.NET 9.0** - Framework principal
- **Entity Framework Core 9.0** - ORM para base de datos
- **SQLite** - Base de datos (archivo local para desarrollo)
- **Swagger/OpenAPI** - Documentación automática de API
- **AutoMapper** (conceptual) - Mapeo de DTOs

## 🚀 Instalación y Configuración

### Prerequisitos
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone [URL_DEL_REPOSITORIO]
   cd Api-University
   ```

2. **Instalar herramientas de Entity Framework**
   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. **Restaurar dependencias**
   ```bash
   dotnet restore
   ```

4. **Crear la base de datos**
   ```bash
   dotnet ef database update
   ```
   > Esto creará automáticamente la base de datos SQLite con datos de prueba

5. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

6. **Acceder a la aplicación**
   - **Swagger UI:** http://localhost:5000/swagger
   - **API Base:** http://localhost:5000/api

## 📊 Base de Datos

### SQLite
- **Archivo:** `estudiantes.db` (se crea automáticamente)
- **Ubicación:** Raíz del proyecto
- **Ventajas:** No requiere instalación de servidor de BD

### Estructura de Tablas
- **Profesores:** 5 registros iniciales
- **Materias:** 10 registros (2 por profesor)
- **Estudiantes:** Tabla para registros de estudiantes
- **EstudianteMateriaProfesores:** Tabla de relación

### Datos de Prueba Incluidos
```sql
-- Profesores
Dr. García, Dra. López, Dr. Martínez, Dra. Rodríguez, Dr. González

-- Materias (ejemplos)
Matemáticas I (Dr. García), Física I (Dr. García)
Química I (Dra. López), Biología I (Dra. López)
Historia (Dr. Martínez), Literatura (Dr. Martínez)
-- ... etc
```

## 🔌 API Endpoints

### Estudiantes
- `GET /api/estudiantes` - Obtener todos los estudiantes
- `GET /api/estudiantes/{id}` - Obtener estudiante específico
- `POST /api/estudiantes` - Crear nuevo estudiante
- `GET /api/estudiantes/{id}/companeros` - Ver compañeros de clase

### Materias
- `GET /api/materias` - Obtener todas las materias
- `GET /api/materias/{id}` - Obtener materia específica

### Profesores
- `GET /api/profesores` - Obtener todos los profesores
- `GET /api/profesores/{id}` - Obtener profesor específico

### Ejemplo de Registro de Estudiante
```json
POST /api/estudiantes
{
  "nombre": "Juan Pérez",
  "email": "juan@email.com",
  "materiaIds": [1, 3, 7]
}
```

### Validaciones Automáticas
- ✅ Exactamente 3 materias seleccionadas
- ✅ Las materias deben existir
- ✅ No puede tener clases con el mismo profesor
- ✅ Email y nombre son obligatorios

## 🧪 Pruebas

### Usando Swagger
1. Ir a http://localhost:5000/swagger
2. Probar endpoints directamente desde la interfaz
3. Ver ejemplos de requests/responses

### Casos de Prueba Recomendados
1. **Registro exitoso:** Seleccionar 3 materias de profesores diferentes
2. **Error por mismo profesor:** Intentar seleccionar 2 materias del mismo profesor
3. **Error por cantidad:** Seleccionar más o menos de 3 materias
4. **Consulta de compañeros:** Ver estudiantes que comparten clases

## 🔧 Configuración Adicional

### Cambiar Base de Datos
Para usar SQL Server o MySQL en lugar de SQLite:

1. **Actualizar `appsettings.json`:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=EstudiantesDB;..."
     }
   }
   ```

2. **Modificar `Startup.cs`:**
   ```csharp
   services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
   );
   ```

### CORS para Frontend
La API está configurada para aceptar requests desde:
- `http://localhost:4200` (Angular desarrollo)

## 🐛 Solución de Problemas

### Error: "dotnet-ef no encontrado"
```bash
dotnet tool install --global dotnet-ef
```

### Error: "Base de datos no existe"
```bash
dotnet ef database update
```

### Error: Referencias circulares JSON
Ya está configurado `ReferenceHandler.IgnoreCycles` en `Startup.cs`

## 📝 Logs y Debugging

- Los logs se muestran en consola durante `dotnet run`
- Nivel de log configurable en `appsettings.json`
- Información detallada de Entity Framework disponible

## 🚀 Despliegue

### Para Producción
1. Cambiar a SQL Server/PostgreSQL
2. Configurar variables de entorno
3. Publicar: `dotnet publish -c Release`

## 👥 Autores

- [Tu Nombre] - Desarrollo inicial

## 📄 Licencia

Este proyecto es parte de un ejercicio académico.

---

## 📞 Soporte

Si tienes problemas durante la instalación o ejecución:

1. Verificar que .NET 9.0 esté instalado: `dotnet --version`
2. Revisar que las migraciones se aplicaron: verificar archivo `estudiantes.db`
3. Comprobar que el puerto 5000 esté disponible
4. Consultar logs en consola para errores específicos

**¡La aplicación está lista para conectarse con el frontend Angular!** 🎉