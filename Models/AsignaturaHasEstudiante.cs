using System;
using System.Collections.Generic;

namespace MyProject.Models;

public partial class AsignaturaHasEstudiante
{
    public int Id { get; set; }

    public int AsignaturaId { get; set; }

    public int EstudianteId { get; set; }

    public virtual Asignatura Asignatura { get; set; } = null!;

    public virtual Estudiante Estudiante { get; set; } = null!;
}
