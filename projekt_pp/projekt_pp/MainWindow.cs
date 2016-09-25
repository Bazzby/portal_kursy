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

	//Okienko główne
	public partial class MainWindow : Form
	{
		private bool isLogged;
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
                User user = User.GetUserById((int)course.idTeacher);
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
            userID = id;
			this.panelM.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
        }

		public void InitializeComponentTeacher(int id)
		{
            userID = id;
            this.panelO.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
        }

		public void InitializeComponentStudent(int id)
		{
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
			ProfilWindow obj = new ProfilWindow(this, userID);
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
                klasaTestowakursBindingSource.Clear();
                var list = Course.GetCourseList();
                foreach (var course in list)
                {
                    User user = User.GetUserById(course.idTeacher);
                    string teacher = user.lastName + " " + user.name;
                    klasaTestowakursBindingSource.Add(new KlasaTestowa_kurs(course.id, course.topic, course.studentsNumber, teacher));
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
                klasaTestowakursBindingSource.Clear();
                var list = Course.GetCourseList();
                foreach (var course in list)
                {
                    User user = User.GetUserById(course.idTeacher);
                    string teacher = user.lastName + " " + user.name;
                    klasaTestowakursBindingSource.Add(new KlasaTestowa_kurs(course.id, course.topic, course.studentsNumber, teacher));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        private void addButtonMPojazdy_Click(object sender, EventArgs e)
        {
            var obj = new AddOrEditCourse(this);
            obj.Text = "Platforma edukacyjna - Dodaj kurs";
            obj.button2.Visible = false;
            obj.Show();
        }

        private void EditCourse(int courseId)
        {
            var obj = new AddOrEditCourse(this, courseId);
            obj.Text = "Platforma edukacyjna - Edytuj kurs";
            obj.button1.Visible = false;
            obj.Show();
        }

        private void tableCarsM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.ColumnIndex == 6)
            {
                var row = e.RowIndex;
                var courseId = (int)tableCarsM.Rows[row].Cells[1].Value;
                EditCourse(courseId);
            }
        }

        private void tableDriversM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var row = e.RowIndex;
                var userId = (int)tableDriversM.Rows[row].Cells[1].Value;
                EditTeacher(userId);
            }
        }

        private void addButtonMKierowcy_Click(object sender, EventArgs e)
        {

            var obj = new AddOrEditTeacher(this);
            obj.Text = "Platforma edukacyjna - Dodaj nauczyciela";
            obj.button2.Visible = false;
            obj.Show();
        }

        private void EditTeacher(int userId)
        {
            var obj = new AddOrEditTeacher(this, userId);
            obj.Text = "Platforma edukacyjna - Edytuj nauczyciela";
            obj.button1.Visible = false;
            obj.Show();
        }

        private void mTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var row = e.RowIndex;
                var userId = (int)mTabelaZlecenia.Rows[row].Cells[1].Value;
                EditStudent(userId);
            }
        }

        private void addButtonMZlecenia_Click(object sender, EventArgs e)
        {
            var obj = new AddOrEditStudent(this);
            obj.Text = "Platforma edukacyjna - Dodaj studenta";
            obj.button2.Visible = false;
            obj.Show();
        }

        private void EditStudent(int userId)
        {
            var obj = new AddOrEditStudent(this, userId);
            obj.Text = "Platforma edukacyjna - Edytuj studenta";
            obj.button1.Visible = false;
            obj.Show();
        }
    }
}
