namespace BazyDanych
{
	class Address
	{
		private string street;
		private string place;
		private int postalCode;
		private int homeNumber;
		private int? localNumber;

		public Address(string place, int postalCode, string street, int homeNumber, int? localNumber = null)
		{
			this.place = place;
			this.postalCode = postalCode;
			this.street = street;
			this.homeNumber = homeNumber;
			this.localNumber = localNumber;
		}
		public string Street
		{
			get { return street; }
			set { street = value; }
		}

		public string Place
		{
			get { return place; }
			set { place = value; }
		}

		public int PostalCode
		{
			get { return postalCode; }
			set { postalCode = value; }
		}

		public int? LocalNumber
		{
			get { return localNumber; }
			set { localNumber = value; }
		}

		public int HomeNumber
		{
			get { return homeNumber; }
			set { homeNumber = value; }
		}
	}
}