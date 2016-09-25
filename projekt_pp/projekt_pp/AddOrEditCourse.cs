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
    public partial class AddOrEditCourse : Form
    {
        private Course course;

        public AddOrEditCourse(MainWindow mainWindow, int courseId)
        {
            InitializeComponent();
            main = mainWindow;
            EditInitialize(courseId);
        }

        public AddOrEditCourse(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
        }

        public AddOrEditCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var courseDto = new CourseDto();

            if (textBox1.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę kursu.\n";
            }
            else
            {
                courseDto.Topic = textBox1.Text;
            }

            if (textBox2.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj liczbę uczestników.\n";
            }
            else
            {
                courseDto.StudentsNumber = Int32.Parse(textBox2.Text);
            }

            if (textBox3.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj hasło kursu.\n";
            }
            else
            {
                courseDto.Password = textBox3.Text;
            }

            if (comboBox1.SelectedIndex > -1)
            {
                string[] pomtable = comboBox1.SelectedItem.ToString().Split(' ');
                courseDto.IdTeacher = User.GetUserIdByName(pomtable[1], pomtable[0]);
            }
            else
                courseDto.IdTeacher = 0;

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    main.AddCourseToDatabase(courseDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Dodawanie kursu nie powiodło się!");
                    throw ex;
                }

            }
        }

        private void EditInitialize(int courseId)
        {
            course = Course.GetCourseById(courseId);

            textBox1.Text = course.topic;
            textBox2.Text = course.studentsNumber.ToString();
            textBox3.Text = course.password;
            comboBox1.Text = User.GetUserNameById(course.idTeacher);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var courseDto = new CourseDto();
            courseDto.Id = course.id;
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            if (textBox1.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę kursu.\n";
            }
            else
            {
                courseDto.Topic = textBox1.Text;
            }

            if (textBox2.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj liczbę uczestników.\n";
            }
            else
            {
                courseDto.StudentsNumber = Int32.Parse(textBox2.Text);
            }

            courseDto.Password = textBox3.Text;

            if (comboBox1.SelectedIndex > -1)
            {
                string[] pomtable = comboBox1.SelectedItem.ToString().Split(' ');
                courseDto.IdTeacher = User.GetUserIdByName(pomtable[1], pomtable[0]);
            }
            else
                courseDto.IdTeacher = 0;

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    Course.UpdateCourse(courseDto);
                    main.UpdateCourse(courseDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Edycja kursu nie powiodła się!");
                    throw ex;
                }

            }
        }
    }
}
