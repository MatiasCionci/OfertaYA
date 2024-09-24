namespace SuperOferta.EjerciciosCurso
{
    public class Profesor
    {
        private int dni;
        private string nombre;
        private string apellido;
        private DateOnly fechaNacimiento;
        private int aniosDeExperiencia;

        public Profesor(int dni, string nombre, string apellido, DateOnly fechaNacimiento, int aniosDeExperiencia)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.aniosDeExperiencia = aniosDeExperiencia;
        }
    }
}
