using System;

namespace BazyDanych
{
	class UserData
	{
		private int userId;
		private string name;
		private string surname;
		private char permissions;
		private Address address;
		private string placeOfBirth;
		private DateTime dateOfBirth;
		private string identifyDocumentNumber;
		private string PESEL;
		private DrivingLicense drivingLicense;
		private string login;
		private string password;

		UserData(int userId, string name, string surname, char permissions, Address address, string placeOfBirth,
			DateTime dateOfBirth, string identifyDocumentNumber, string PESEL, DrivingLicense drivingLicense, string login, string password)
		{
			this.userId = userId;
			this.name = name;
			this.surname = surname;
			this.permissions = permissions;
			this.address = address;
			this.placeOfBirth = placeOfBirth;
			this.dateOfBirth = dateOfBirth;
			this.identifyDocumentNumber = identifyDocumentNumber;
			this.PESEL = PESEL;
			this.drivingLicense = drivingLicense;
			this.login = login;
			this.password = password;
		}
		public int UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Surname
		{
			get { return surname; }
			set { surname = value; }
		}

		public char Permissions
		{
			get { return permissions; }
			set { permissions = value; }
		}

		public Address Address
		{
			get { return address; }
			set { address = value; }
		}

		public string PlaceOfBirth
		{
			get { return placeOfBirth; }
			set { placeOfBirth = value; }
		}

		public DateTime DateOfBirth
		{
			get { return dateOfBirth; }
			set { dateOfBirth = value; }
		}

		public string IdentifyDocumentNumber
		{
			get { return identifyDocumentNumber; }
			set { identifyDocumentNumber = value; }
		}

		public string Pesel
		{
			get { return PESEL; }
			set { PESEL = value; }
		}

		public DrivingLicense DrivingLicense
		{
			get { return drivingLicense; }
			set { drivingLicense = value; }
		}

		public string Login
		{
			get { return login; }
			set { login = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}
	}
}