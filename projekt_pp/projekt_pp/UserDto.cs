using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    public class UserDto
    {
        public int Id { get; set; }
        public char Permissions { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
