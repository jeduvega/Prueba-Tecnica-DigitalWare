using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notas_Estudiantes_DigitalWare.Data;
using Notas_Estudiantes_DigitalWare.Models;
using System;
using System.Collections.Generic;

namespace Notas_Estudiantes_DigitalWare.Pages
{
    public class EditarModel : PageModel
    {

        public Notas NotaEdit = new Notas();
        public NotaAlumno Nota = new NotaAlumno();


        public void OnPost()
        {
            int id = int.Parse(Request.Form["id"]);
            
            Nota.Id_Estudiante = int.Parse(Request.Form["nombres"]);
            Nota.Id_Materia = int.Parse(Request.Form["materias"]);
            Nota.Nota = Request.Form["nota"];
            Nota.Periodo = Request.Form["periodo"];

            try
            {
                ConnectionDB NotasDB = new ConnectionDB();

                NotasDB.UpdateNotas(id, Nota);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
            }

            Response.Redirect("/");

        }

        public void OnGet()
        {
            int id = int.Parse( Request.Query["id"]);

            try
            {
                ConnectionDB NotasDB = new ConnectionDB();

                NotaEdit =NotasDB.GetNotasById(id);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception: " + ex.Message);
            }

        }
    }
}
