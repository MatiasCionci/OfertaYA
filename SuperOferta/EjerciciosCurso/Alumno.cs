namespace SuperOferta.EjerciciosCurso
{
    public class Alumno
    {
        private int dni;
        private string nombre;
        private string apellido;
        private DateOnly fechaNacimiento;
        private bool siTrabaja;

        public Alumno(int dni, string nombre, string apellido, DateOnly fechaNacimiento, bool siTrabaja)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.siTrabaja = siTrabaja;
        }
    }
}
