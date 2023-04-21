using System;
using System.Collections.Generic;

namespace MyProject.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Rut { get; set; }

    public string? Dirección { get; set; }

    public string? Email { get; set; }

    public int? Edad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<AsignaturaHasEstudiante> AsignaturaHasEstudiantes { get; set; } = new List<AsignaturaHasEstudiante>();
}
