using Microsoft.AspNetCore.Mvc;
using Notas_Estudiantes_DigitalWare.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Notas_Estudiantes_DigitalWare.Data
{
    public class ConnectionDB
    {
        private string conecctionString
            = "Data Source=ELITEBOOK\\SQLEXPRESS ; Initial Catalog= Colegio; User=sa; Password=admin1234";

       

        public List<Estudiantes> GetEstudiantes()
        {
            List<Estudiantes> Estudiantes = new List<Estudiantes>();

            string query = "SELECT id, Nombre " +
                            "FROM Estudiantes";


            using (SqlConnection connection = new SqlConnection(conecctionString) )
            {

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Estudiantes Estudiante = new Estudiantes();

                    Estudiante.Id = reader.GetInt32(0);
                    Estudiante.Nombre = reader.GetString(1);
                    Estudiantes.Add(Estudiante);
                }

                reader.Close();
                connection.Close();

            }

            return Estudiantes;
        }

        public List<Materias> GetMaterias()
        {
            List<Materias> Materias = new List<Materias>();
            string query = "SELECT id, Nombre " +
                            "FROM Materias";


            using (SqlConnection connection = new SqlConnection(conecctionString))
            {

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Materias Materia = new Materias();

                    Materia.Id = reader.GetInt32(0);
                    Materia.Nombre = reader.GetString(1);
                    Materias.Add(Materia);
                }

                reader.Close();
                connection.Close();

            }

            return Materias;


        }

        public List<Notas> GetAllNotas()
        {
            List<Notas> Notas = new List<Notas>();


            string query = "SELECT TOP 10 N.id,E.Nombre,M.Nombre, N.nota, N.periodo " +
                 "FROM Notas N " +
                 "INNER JOIN Estudiantes E " +
                 "ON N.id_estudiante = E.id " +
                 "INNER JOIN Materias M " +
                 "ON M.id = N.id_materia ";


            using (SqlConnection connection = new SqlConnection(conecctionString))
            {

                SqlCommand command = new SqlCommand();


                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
               
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Notas Nota = new Notas();

                    Nota.Id = reader.GetInt32(0);
                    Nota.Nombre = reader.GetString(1);
                    Nota.Materia = reader.GetString(2);
                    Nota.Nota = reader.GetString(3);
                    Nota.Periodo = reader.GetInt32(4);
                    Notas.Add(Nota);
                }

                reader.Close();
                connection.Close();

            }


            return Notas;

        }

        public List<Notas> GetNotas(int id)
        {


            List<Notas> Notas = new List<Notas>();


            string query = "SELECT E.id,E.Nombre,M.Nombre, N.nota, N.periodo " +
                 "FROM Notas N " +
                 "INNER JOIN Estudiantes E " +
                 "ON N.id_estudiante = E.id " +
                 "INNER JOIN Materias M " +
                 "ON M.id = N.id_materia " +
                 "WHERE id_estudiante = @id ";


            using (SqlConnection connection = new SqlConnection(conecctionString))
            {

                SqlCommand command = new SqlCommand();

                SqlParameter parameterId = new SqlParameter();
                parameterId.SqlDbType = SqlDbType.Int;
                parameterId.Direction = ParameterDirection.Input;
                parameterId.ParameterName = "@id";
                parameterId.Value = id;

                command.Connection=connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(parameterId);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Notas Nota = new Notas();

                    Nota.Id = reader.GetInt32(0);
                    Nota.Nombre = reader.GetString(1);
                    Nota.Materia = reader.GetString(2);
                    Nota.Nota = reader.GetString(3);
                    Nota.Periodo = reader.GetInt32(4);
                    Notas.Add(Nota);
                }

                reader.Close();
                connection.Close();

            }


            return Notas;
        }

        public void PostNotas( NotaAlumno notas)
        {

            string query = "INSERT INTO Notas (id_estudiante,id_materia,nota,periodo) " +
                            "VALUES (@id_estudiante,@id_materia,@nota,@periodo)";
            try
            {

                using (SqlConnection connection = new SqlConnection(conecctionString))
                {

                    SqlCommand command = new SqlCommand();


                    //categoriesAdapter.SelectCommand.Parameters.Add( "@CategoryName", SqlDbType.VarChar, 80).Value = "toasters";

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@id_estudiante", notas.Id_Estudiante);
                    command.Parameters.AddWithValue("@id_materia", notas.Id_Materia);
                    command.Parameters.AddWithValue("@nota", notas.Nota);
                    command.Parameters.AddWithValue("@periodo", notas.Periodo);


                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();

                }


            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
            }
            Console.WriteLine("Agregado con exito");

            


        }

        public void DeleteNota (int id)
        {
            
            string query = "DELETE Notas " +
                            "WHERE id=@id ";



            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {

                    SqlCommand command = new SqlCommand();


                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
            }


        }

        public Notas GetNotasById(int id)
        {
            Notas Nota = new Notas();

            string query = "SELECT N.id ,E.Nombre ,N.id_estudiante ,M.Nombre ,N.id_materia , N.nota, N.periodo  " +
                           "FROM Notas N " +
                           "INNER JOIN Estudiantes E " +
                           "ON N.id_estudiante = E.id " +
                           "INNER JOIN Materias M " +
                           "ON M.id = N.id_materia " +
                           "WHERE N.id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {

                    SqlCommand command = new SqlCommand();


                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                      
                        Nota.Id = reader.GetInt32(0);
                        Nota.Nombre = reader.GetString(1);
                        Nota.Id_Estudiante = reader.GetInt32(2);
                        Nota.Materia = reader.GetString(3);
                        Nota.Id_Materia = reader.GetInt32(4);
                        Nota.Nota = reader.GetString(5);
                        Nota.Periodo = reader.GetInt32(6);
                
                    }

                    reader.Close();

                    connection.Close();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
            }

            return Nota;

        }

        public void UpdateNotas (int id, NotaAlumno nota)
        {
            string query = "UPDATE Notas  " +
                            "SET id_estudiante = @id_estudiante,id_materia = @id_materia, nota = @nota, periodo = @periodo " +
                            "WHERE id = @id";
           

            try
            {

                using (SqlConnection connection = new SqlConnection(conecctionString))
                {

                    SqlCommand command = new SqlCommand();


                    //categoriesAdapter.SelectCommand.Parameters.Add( "@CategoryName", SqlDbType.VarChar, 80).Value = "toasters";

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@id_estudiante", nota.Id_Estudiante);
                    command.Parameters.AddWithValue("@id_materia", nota.Id_Materia);
                    command.Parameters.AddWithValue("@nota", nota.Nota);
                    command.Parameters.AddWithValue("@periodo", nota.Periodo);


                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();

                }


            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Error : " + ex.Message);
            }
            Console.WriteLine("Agregado con exito");


        }
    }
}
