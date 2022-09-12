namespace Notas_Estudiantes_DigitalWare.Models
{
    public class NotaAlumno
    {
        public int Id { get; set; }
        public int Id_Estudiante { get; set; }
        public int Id_Materia { get; set; }
        public string Nota { get; set; }
        public string Periodo { get; set; }
    }

    public class Notas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Id_Estudiante { get; set; }
        public string Materia { get; set; }
        public int Id_Materia { get; set; }
        public string Nota { get; set; }
        public int Periodo { get; set; }
    }


}



