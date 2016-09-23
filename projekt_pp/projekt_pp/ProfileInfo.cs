using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyDanych
{
	public partial class ProfileInfo : Form
	{
		public ProfileInfo()
		{
			InitializeComponent();
		}

		private void ProfileInfo_Load(object sender, EventArgs e, UserData user)
		{
			Name.Text = user.Name;
			surname.Text = user.Surname;
			login.Text = user.Login;
			street.Text = user.Address.Street;
			if (user.Address.LocalNumber.HasValue)
			{
				localNumber.Text = user.Address.LocalNumber.Value.ToString();
			}
			homeNumber.Text = user.Address.HomeNumber.ToString();
			birthDate.Text = user.DateOfBirth.ToString();
			idNum.Text = user.IdentifyDocumentNumber;
			pesel.Text = user.Pesel;
			permissions.Text = user.Permissions.ToString();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Close();
		}
	}
}