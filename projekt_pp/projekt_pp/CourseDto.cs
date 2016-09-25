using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_pp
{
    public class CourseDto
    {
        public int Id { get; set; }
        public int IdTeacher { get; set; }
        public int StudentsNumber { get; set; }
        public string Topic { get; set; }
        public string Password { get; set; }
    }
}
