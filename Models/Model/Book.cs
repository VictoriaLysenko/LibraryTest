using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Book
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Code { get; set; }

        public int? LibraryId { get; set; }

        public virtual Library Library { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
