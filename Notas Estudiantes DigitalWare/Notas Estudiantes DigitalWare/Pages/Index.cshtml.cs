using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Notas_Estudiantes_DigitalWare.Data;
using Notas_Estudiantes_DigitalWare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notas_Estudiantes_DigitalWare.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Notas> Notas = new List<Notas>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnPostDelete(int id) 
        {
            try
            {
                ConnectionDB NotasDB = new ConnectionDB();

                NotasDB.DeleteNota(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
            }

            Response.Redirect("/");
        }


        public void OnGet()
        {
            try
            {

                ConnectionDB NotasDB = new ConnectionDB();

                Notas = NotasDB.GetAllNotas();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
            }


        }
    }
}
