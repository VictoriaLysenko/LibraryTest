using Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LibraryTestContext : DbContext
    {
        public DbSet<University> Universities { get; set; }

        public DbSet<Library> Libraries { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Student> Students { get; set; }

        static LibraryTestContext()
        {
        }

        public LibraryTestContext() : base("MyConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
