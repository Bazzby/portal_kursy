using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_pp
{
    public partial class AddOrEditStudent : Form
    {
        private User user;

        public AddOrEditStudent(MainWindow mainWindow, int userId)
        {
            InitializeComponent();
            main = mainWindow;
            EditInitialize(userId);
        }

        public AddOrEditStudent(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
        }

        public AddOrEditStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var userDto = new UserDto();
            userDto.Permissions = 'S';

            if (textBox1.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj login.\n";
            }
            else
            {
                userDto.Login = textBox1.Text;
            }

            if (textBox2.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj hasło.\n";
            }
            else
            {
                userDto.Password = textBox2.Text;
            }

            if (textBox3.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj imię.\n";
            }
            else
            {
                userDto.Name = textBox3.Text;
            }

            if (textBox4.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwisko.\n";
            }
            else
            {
                userDto.LastName = textBox4.Text;
            }

            if (textBox5.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj maila.\n";
            }
            else
            {
                userDto.Mail = textBox5.Text;
            }


            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    main.AddUserToDatabase(userDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Dodawanie studenta nie powiodło się!");
                    throw ex;
                }

            }
        }

        private void EditInitialize(int userId)
        {
            user = User.GetUserById(userId);

            textBox1.Text = user.login;
            textBox2.Text = user.password;
            textBox3.Text = user.name;
            textBox4.Text = user.lastName;
            textBox5.Text = user.mail;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userDto = new UserDto();
            userDto.Id = user.id;
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";
            userDto.Permissions = 'S';

            if (textBox1.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj login.\n";
            }
            else
            {
                userDto.Login = textBox1.Text;
            }

            if (textBox2.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj hasło.\n";
            }
            else
            {
                userDto.Password = textBox2.Text;
            }

            if (textBox3.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj imię.\n";
            }
            else
            {
                userDto.Name = textBox3.Text;
            }

            if (textBox4.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwisko.\n";
            }
            else
            {
                userDto.LastName = textBox4.Text;
            }

            if (textBox5.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj maila.\n";
            }
            else
            {
                userDto.Mail = textBox5.Text;
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    User.UpdateUser(userDto);
                    main.UpdateUser(userDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Edycja studenta nie powiodła się!");
                    throw ex;
                }

            }
        }
    }
}
