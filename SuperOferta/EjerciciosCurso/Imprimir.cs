﻿using SuperOferta.EjerciciosLibros;

namespace SuperOferta.EjerciciosCurso
{
    public class Imprimir
    {
        Alumno alumno1 = new Alumno(34513962, "Matias", "Cionci", new DateOnly(1989, 5, 28), true);
        Alumno alumno2 = new Alumno(34513962, "Marcus", "Cionci", new DateOnly(2001, 12, 6), false); 
        List<Alumno> alumnos=new List<Alumno> ();
        Profesor profesor=new Profesor(34323234,"Martin","CapaBlanca",new DateOnly(1985,8,9),25);
        Curso curso1 = new Curso(".Net", 30);
        
        public void imprimir()
        {
            curso1.setProfesor(profesor);
            curso1.agregarAlumno(alumno1);
            curso1.agregarAlumno(alumno1);
            Console.WriteLine($"nombre del curso es{curso1.getNombre}");
        }
    }
}
