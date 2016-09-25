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
    public partial class ProfilWindow : Form
    {
        private User user;
        private int id;
        public ProfilWindow(MainWindow mainWindow, int userID)
        {
            InitializeComponent();
            main = mainWindow;
            id = userID;
            EditInitialize(userID);
        }

        public ProfilWindow()
        {
            InitializeComponent();
        }

        public void EditInitialize(int userID)
        {
            user = User.GetUserById(userID);
            textBox1.Text = user.login;
            textBox3.Text = user.name;
            textBox4.Text = user.lastName;
            textBox5.Text = user.mail;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangingPassword obj = new ChangingPassword(id);
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userDto = new UserDto();
            userDto.Id = user.id;
            userDto.Permissions = user.permissions;
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

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
                    if (userDto.Permissions == 'N' || userDto.Permissions == 'S')
                        main.UpdateUser(userDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Edytowanie profilu nie powiodło się!");
                    throw ex;
                }

            }
        }
    }
}
