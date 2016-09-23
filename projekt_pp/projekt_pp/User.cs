using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Portal
{
    class User
    {
        public int id;
        public char permissions;
        public string name;
        public string lastName;
        public string mail;
        public string login;
        public string password;

        public User(UserDto userDto)
        {
            id = userDto.Id;
            permissions = userDto.Permissions;
            name = userDto.Name;
            lastName = userDto.LastName;
            mail = userDto.Mail;
            login = userDto.Login;
            password = userDto.Password;
        }

        public User()
        {
        }

        public static IList<User> GetUserList(char permission)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<User>();
            var userDto = new UserDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();
                string query = "";
                if (permission == 'S')
                    query = "SELECT * FROM projekt_pp.uzytkownik WHERE uzytkownik.uprawnienia = \"S\";";
                else if (permission == 'N')
                    query = "SELECT * FROM projekt_pp.uzytkownik WHERE uzytkownik.uprawnienia = \"N\";";

                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    userDto.Id = dataReader.GetInt32(0);
                    userDto.Mail = dataReader.GetString(4);
                    userDto.Name = dataReader.GetString(5);
                    userDto.LastName = dataReader.GetString(6);

                    var user = new User(userDto);
                    list.Add(user);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static User GetUserById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var userDto = new UserDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_pp.uzytkownik where uzytkownik.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    userDto.Id = dataReader.GetInt32(0);
                    userDto.Permissions = dataReader.GetChar(1);
                    userDto.Login = dataReader.GetString(2);
                    userDto.Password = dataReader.GetString(3);
                    userDto.Mail = dataReader.GetString(4);
                    userDto.Name = dataReader.GetString(5);
                    userDto.LastName = dataReader.GetString(6);

                    connection.Close();
                    return new User(userDto);
                }
                else
                {
                    connection.Close();
                    return new User();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new User();
        }

        public static void AddUser(UserDto userDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_pp.uzytkownik VALUES(null, \"" +
                                userDto.Permissions +
                                 "\",\"" +
                                userDto.Login +
                                "\",\"" +
                                userDto.Password +
                                "\",\"" +
                                userDto.Mail +
                                "\",\"" +
                                userDto.Name +
                                "\",\"" +
                                userDto.LastName +
                                "\");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano użytkownika");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void UpdateUser(UserDto userDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_pp.uzytkownik " +
                               "SET imie = \"" +
                                userDto.Name +
                                "\", nazwisko = \"" +
                                userDto.LastName +
                                "\", mail = \"" +
                                userDto.Mail +
                                "\" WHERE id = " +
                                userDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano użytkownika");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static IList<string> GetTeacherNameList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<string>();
            string pom = "";

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT nazwisko, imie FROM projekt_pp.uzytkownik WHERE uzytkownik.uprawnienia = \"N\"";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    pom = dataReader.GetString(0) + " " + dataReader.GetString(1);
                    list.Add(pom);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }
    }
}
