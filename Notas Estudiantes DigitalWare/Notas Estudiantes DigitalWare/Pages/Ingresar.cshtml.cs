using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Notas_Estudiantes_DigitalWare.Data;
using Notas_Estudiantes_DigitalWare.Models;
using System;
using System.Collections.Generic;

namespace Notas_Estudiantes_DigitalWare.Pages
{
    public class IngresarModel : PageModel
    {

        public List<Estudiantes> Estudiantes = new List<Estudiantes>();
        public List<Materias> Materias = new List<Materias>();
        public NotaAlumno notaAlumno = new NotaAlumno();
       
        public void OnGet()
        {

            try
            {
                ConnectionDB EstudiantesDB = new ConnectionDB();

                Materias = EstudiantesDB.GetMaterias();

                Estudiantes= EstudiantesDB.GetEstudiantes();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception: " + ex.Message);
            }


        }

        public void OnPost()
        {

            try
            {
                ConnectionDB NotasBD = new ConnectionDB();

                notaAlumno.Id_Estudiante = int.Parse(Request.Form["nombres"]);
                notaAlumno.Id_Materia = int.Parse(Request.Form["materias"]);
                notaAlumno.Nota = Request.Form["nota"];
                notaAlumno.Periodo = Request.Form["periodo"];

                NotasBD.PostNotas(notaAlumno);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
                
            }

            Response.Redirect("/");
            

        }
    }
}
