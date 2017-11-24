using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public int? BookId { get; set; }

        public virtual Book Book { get; set; }

    }
}
