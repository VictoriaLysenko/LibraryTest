using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Library
    {
        public int LibraryId { get; set; }

        public string Address { get; set; }

        public int? UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
