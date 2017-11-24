using DAL;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class LibraryController : ApiController
    {
        private readonly LibraryTestContext db;

        public LibraryController()
        {
            db = new LibraryTestContext();
        }

        [Route("libraries")]
        public IEnumerable<Library> GetLibraries()
        {
            return db.Libraries;
        }

        [Route("libraries/{id}")]
        public Library GetById(int id)
        {
            return db.Libraries.FirstOrDefault(t => t.LibraryId == id);
        }

        [Route("libraries")]
        [HttpPost]
        public void Create(Library library)
        {
            db.Libraries.Add(library);
            db.SaveChanges();
        }

        [Route("libraries")]
        [HttpDelete]
        public void DeleteLibrary(int id)
        {
            var library = db.Libraries.FirstOrDefault(t => t.LibraryId == id);
            db.Entry(library).State = System.Data.Entity.EntityState.Deleted;

            db.SaveChanges();
        }

        [Route("libraries")]
        [HttpPut]
        public void UpdateLibrary(Library updatedLibrary)
        {
            var library = db.Libraries.Where(t => t.LibraryId == updatedLibrary.LibraryId).FirstOrDefault();

            if (library != null)
            {
                library.Address = updatedLibrary.Address;
            }
        }
    }
}
