using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portal
{
	class Functions
	{
		public static string GetConnectionString()
		{
			return "server=127.0.0.1;uid=root;" +
				"pwd=root;database=projekt_pp";
		}
	}

}
