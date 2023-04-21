using System;
using System.Collections.Generic;

namespace MyProject.Models;

public partial class Asignatura
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public string? Código { get; set; }

    public DateOnly? FechaActualización { get; set; }

    public virtual ICollection<AsignaturaHasEstudiante> AsignaturaHasEstudiantes { get; set; } = new List<AsignaturaHasEstudiante>();
}
