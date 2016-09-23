using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Portal
{
    class Course
    {
        public int id;
        public int idTeacher;
        public int studentsNumber;
        public string topic;
        public string password;

        public Course(CourseDto courseDto)
        {
            id = courseDto.Id;
            idTeacher = courseDto.IdTeacher;
            studentsNumber = courseDto.StudentsNumber;
            topic = courseDto.Topic;
            password = courseDto.Password;
        }

        public Course()
        {

        }

        public static IList<Course> GetCourseList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Course>();
            var courseDto = new CourseDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_pp.kurs;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    courseDto.Id = dataReader.GetInt32(0);
                    courseDto.IdTeacher = dataReader.GetInt32(1);
                    courseDto.StudentsNumber = dataReader.GetInt32(2);
                    courseDto.Topic = dataReader.GetString(3);
                    courseDto.Password = dataReader.GetString(4);

                    var course = new Course(courseDto);
                    list.Add(course);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static Course GetCourseById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var courseDto = new CourseDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_pp.kurs where kurs.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    courseDto.Id = dataReader.GetInt32(0);
                    courseDto.IdTeacher = dataReader.GetInt32(1);
                    courseDto.StudentsNumber = dataReader.GetInt32(2);
                    courseDto.Topic = dataReader.GetString(3);
                    courseDto.Password = dataReader.GetString(4);

                    connection.Close();
                    return new Course(courseDto);
                }
                else
                {
                    connection.Close();
                    return new Course();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new Course();
        }

        public static void AddCourse(CourseDto courseDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_pp.kurs VALUES(null, " +
                                courseDto.IdTeacher +
                                 "," +
                                courseDto.StudentsNumber +
                                ",\"" +
                                courseDto.Topic +
                                "\",\"" +
                                courseDto.Password +
                                "\");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano kurs");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void UpdateCourse(CourseDto courseDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_pp.kurs " +
                               "SET id_nauczyciel = " +
                                courseDto.IdTeacher +
                                ", liczba_miejsc = " +
                                courseDto.StudentsNumber +
                                ", temat = \"" +
                                courseDto.Topic +
                                "\" WHERE id = " +
                                courseDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano kurs");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
    }
}
