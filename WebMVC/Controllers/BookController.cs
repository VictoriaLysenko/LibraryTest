using Models.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly RestClient client;
        // GET: Book
        public string Index()
        {
            return "Books";
        }

        public BookController()
        {
            client = new RestClient("http://localhost:49361/");
        }

        public ActionResult GetBooks()
        {
            RestRequest request = new RestRequest("api/books", Method.GET);
            IRestResponse<List<Book>> response = client.Execute<List<Book>>(request);

            return View(response.Data.ToList());
        }

        public ActionResult Details(int id)
        {
            RestRequest request = new RestRequest("api/books/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            IRestResponse<Book> response = client.Execute<Book>(request);

            return View(response.Data);
        }

        public ActionResult Create(Book book)
        {
            if (book.BookId != 0)
            {
                RestRequest request = new RestRequest("api/books", Method.POST);
                request.AddObject(book);
                IRestResponse response = client.Execute(request);
            }

            return View(book);
        }

        public ActionResult Delete(int id)
        {
            RestRequest request = new RestRequest("api/books/{id}", Method.DELETE);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            IRestResponse response = client.Execute(request);
            return RedirectToAction("GetBooks");
        }
        
        
         public ActionResult Put(int id, Book book)
        {
            RestRequest request1 = new RestRequest("api/books/{id}", Method.GET);
            request1.AddParameter("id", id, ParameterType.UrlSegment);

            IRestResponse<Book> response1 = client.Execute<Book>(request1);

            RestRequest request = new RestRequest("api/books", Method.PUT);
            request.AddObject(book);
            IRestResponse response = client.Execute(request);
            return View(response1.Data);
        }
        
    }
}