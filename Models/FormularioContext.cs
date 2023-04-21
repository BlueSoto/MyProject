using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Models;

public partial class FormularioContext : DbContext
{
    public FormularioContext()
    {
    }

    public FormularioContext(DbContextOptions<FormularioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<AsignaturaHasEstudiante> AsignaturaHasEstudiantes { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
        
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asignatura");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Código)
                .HasMaxLength(45)
                .HasColumnName("código");
            entity.Property(e => e.Descripción)
                .HasMaxLength(100)
                .HasColumnName("descripción");
            entity.Property(e => e.FechaActualización).HasColumnName("fecha_actualización");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AsignaturaHasEstudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asignatura_has_estudiante");

            entity.HasIndex(e => e.AsignaturaId, "fk_Asignatura_has_Estudiante_Asignatura_idx");

            entity.HasIndex(e => e.EstudianteId, "fk_Asignatura_has_Estudiante_Estudiante1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AsignaturaId)
                .HasColumnType("int(11)")
                .HasColumnName("Asignatura_id");
            entity.Property(e => e.EstudianteId)
                .HasColumnType("int(11)")
                .HasColumnName("Estudiante_id");

            entity.HasOne(d => d.Asignatura).WithMany(p => p.AsignaturaHasEstudiantes)
                .HasForeignKey(d => d.AsignaturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Asignatura_has_Estudiante_Asignatura");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.AsignaturaHasEstudiantes)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Asignatura_has_Estudiante_Estudiante1");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudiante");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Dirección)
                .HasMaxLength(45)
                .HasColumnName("dirección");
            entity.Property(e => e.Edad)
                .HasColumnType("int(11)")
                .HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Rut)
                .HasMaxLength(10)
                .HasColumnName("rut");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
