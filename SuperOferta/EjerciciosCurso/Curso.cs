using SuperOferta.EjerciciosCurso;

namespace SuperOferta.EjerciciosLibros
{
    public class Curso
    {
        private string nombre;
        private int maxAlumno;
        private Profesor profesor;
        private List<Alumno> alumnoList = new List<Alumno>();

        public Curso(string nombre, int maxAlumno)
        {
            this.nombre = nombre;
            this.maxAlumno = maxAlumno;
            

        }
        public void agregarAlumno( Alumno alum)
        {
            alumnoList.Add(alum);
           
        }
        public string getNombre(){
            return this.nombre;
        }
        public void setProfesor(Profesor profesor)
        {
            this.profesor = profesor;
        }
        public Profesor getProfesor()
        {
            return this.profesor;
        }
    }
}

