using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class University
    {
        public int UniversityId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Library> Libraries { get; set; }

    }
}
