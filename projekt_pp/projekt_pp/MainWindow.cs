using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portal
{

	//Okienko główne
	public partial class MainWindow : Form
	{
		private bool isLogged;
        private char permission;
        private int userID;
		public MainWindow()
		{
			InitializeComponent();
			InitializeComponentStart();
			isLogged = false;
			profilLabel.Visible = false;
		}


		private void Form2_Load(object sender, EventArgs e)
		{
            var studentList = User.GetUserList('S');
            foreach (var user in studentList)
            {
                klasaTestowauserBindingSource.Add(new KlasaTestowa_user(user.id, user.name, user.lastName, user.mail));
            }

            studentList = User.GetUserList('N');
            foreach (var user in studentList)
            {
                klasaTestowateacherBindingSource.Add(new KlasaTestowa_teacher(user.id, user.name, user.lastName, user.mail));
            }

            var courseList = Course.GetCourseList();
            foreach (var course in courseList)
            {
                User user = User.GetUserById(course.idTeacher);
                string teacher = user.lastName + " " + user.name;
                klasaTestowakursBindingSource.Add(new KlasaTestowa_kurs(course.id, course.topic, course.studentsNumber, teacher));
            }
        }

        private void InitializeComponentStart()
		{
			this.panelS.Visible = true;
			this.panelS.SendToBack();
			this.panelM.Visible = false;
			this.panelO.Visible = false;
			this.panelK.Visible = false;
		}

		public void InitializeComponentAdmin(int id)
		{
            permission = 'A';
            userID = id;
			this.panelM.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
        }

		public void InitializeComponentTeacher(int id)
		{
            permission = 'O';
            userID = id;
            this.panelO.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
        }

		public void InitializeComponentStudent(int id)
		{
            permission = 'K';
            userID = id;
            this.panelK.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
        }

		private void zalogujSLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!isLogged)
			{
				LoginWindow obj = new LoginWindow(this);
				isLogged = true;
				obj.Show();
			}
			else
			{
				this.panelM.Visible = false;
				this.panelO.Visible = false;
				this.panelK.Visible = false;
				this.logowanieLabel.Text = "Zaloguj";
				this.profilLabel.Visible = false;
				isLogged = false;
			}
		}

		private void profilLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ProfilWindow obj = new ProfilWindow();
			obj.Show();
		}

		public void AddUserToDatabase(UserDto userDto)
		{
			try
			{
				User.AddUser(userDto);
				klasaTestowauserBindingSource.Clear();
				var list = User.GetUserList(userDto.Permissions);
				foreach (var user in list)
				{
                    klasaTestowauserBindingSource.Add(new KlasaTestowa_user(user.id, user.name, user.lastName, user.mail));
				}

			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				throw ex;
			}
		}

        public void UpdateUser(UserDto userDto)
        {
            try
            {
                klasaTestowauserBindingSource.Clear();
                var list = User.GetUserList(userDto.Permissions);
                foreach (var user in list)
                {
                    klasaTestowauserBindingSource.Add(new KlasaTestowa_user(user.id, user.name, user.lastName, user.mail));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddTeacherToDatabase(UserDto userDto)
        {
            try
            {
                User.AddUser(userDto);
                klasaTestowateacherBindingSource.Clear();
                var list = User.GetUserList(userDto.Permissions);
                foreach (var user in list)
                {
                    klasaTestowateacherBindingSource.Add(new KlasaTestowa_teacher(user.id, user.name, user.lastName, user.mail));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateTeacher(UserDto userDto)
        {
            try
            {
                klasaTestowateacherBindingSource.Clear();
                var list = User.GetUserList(userDto.Permissions);
                foreach (var user in list)
                {
                    klasaTestowateacherBindingSource.Add(new KlasaTestowa_teacher(user.id, user.name, user.lastName, user.mail));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddCourseToDatabase(CourseDto courseDto)
        {
            try
            {
                Course.AddCourse(courseDto);
                klasaTestowauserBindingSource.Clear();
                var list = Course.GetCourseList();
                User user = User.GetUserById(courseDto.IdTeacher);
                string teacher = user.lastName + " " + user.name;
                foreach (var course in list)
                {
                    klasaTestowauserBindingSource.Add(new KlasaTestowa_kurs(course.id, course.topic, course.studentsNumber, teacher));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateCourse(CourseDto courseDto)
        {
            try
            {
                klasaTestowauserBindingSource.Clear();
                var list = Course.GetCourseList();
                User user = User.GetUserById(courseDto.IdTeacher);
                string teacher = user.lastName + " " + user.name;
                foreach (var course in list)
                {
                    klasaTestowauserBindingSource.Add(new KlasaTestowa_kurs(course.id, course.topic, course.studentsNumber, teacher));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
