using DAL;
using Models.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rest = new UniversityRest();
            //using (LibraryTestContext db = new LibraryTestContext("MyConnectionString"))
            //{
            //    db.Universities.Add(new University { UniversityId = 1, Name = "Oxford", Address = "Baskerville, 12" });
            //    db.Universities.Add(new University { UniversityId = 2, Name = "Harvard", Address = "Yew, 13" });

            //    db.Libraries.Add(new Library { LibraryId = 1, Address = "Green avenue, 6", UniversityId = 1 });
            //    db.Libraries.Add(new Library { LibraryId = 2, Address = "Dest avenue, 34", UniversityId = 1 });
            //    db.Libraries.Add(new Library { LibraryId = 3, Address = "Hiil avenue, 16", UniversityId = 2 });
            //    db.Libraries.Add(new Library { LibraryId = 4, Address = "Listad avenue, 33", UniversityId = 2 });

            //    db.Books.Add(new Book { BookId = 1, Name = "The Hunger Games", Author = "Suzanne Collins", Code = "F00001", LibraryId = 1 });
            //    db.Books.Add(new Book { BookId = 2, Name = "To Kill a Mockingbird", Author = "Harper Lee", Code = "F00002", LibraryId = 1 });
            //    db.Books.Add(new Book { BookId = 3, Name = "Pride and Prejudice", Author = "Jane Austen", Code = "F00003", LibraryId = 2 });
            //    db.Books.Add(new Book { BookId = 4, Name = "The Book Thief", Author = "Markus Zusak", Code = "F00004", LibraryId = 3 });
            //    db.Books.Add(new Book { BookId = 5, Name = "Gone with the Wind", Author = "Margaret Mitchell", Code = "F00005", LibraryId = 3 });
            //    db.Books.Add(new Book { BookId = 6, Name = "The Little Prince", Author = "Antoine de Saint-Exupéry", Code = "F00006", LibraryId = 4 });

            //    db.Students.Add(new Student { StudentId = 1, Forename = "John", Surname = "McCartney", BookId = 1 });
            //    db.Students.Add(new Student { StudentId = 2, Forename = "Anna", Surname = "Lien", BookId = 2 });
            //    db.Students.Add(new Student { StudentId = 3, Forename = "Samanta", Surname = "Jonson", BookId = 3 });
            //    db.Students.Add(new Student { StudentId = 4, Forename = "Pitter", Surname = "McCoy", BookId = 4 });
            //    db.Students.Add(new Student { StudentId = 5, Forename = "Lisa", Surname = "McCartney", BookId = 5 });
            //    db.Students.Add(new Student { StudentId = 6, Forename = "Jason", Surname = "Statcer", BookId = 6 });

            //    db.SaveChanges();

            //    var query = from u in db.Universities
            //                select u;

            //    foreach (var item in query)
            //    {
            //        Console.WriteLine("Name - {0}, Address - {1}", item.Name, item.Address);
            //    }

            //    Console.ReadLine();
            //}
        }
    }

    public class UniversityRest
    {
        private RestClient client;

        public UniversityRest()
        {
            client = new RestClient("http://localhost:49361");
        }

        public List<University> GetUniversities()
        {
            RestRequest request = new RestRequest("/api/universities", Method.GET) { RequestFormat = DataFormat.Json };
            IRestResponse<List<University>> response = client.Execute<List<University>>(request);
            return response.Data;
        }
    }
}
