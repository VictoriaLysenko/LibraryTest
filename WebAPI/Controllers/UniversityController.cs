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
    public class UniversityController : ApiController
    {
        [Route("universities")]
        public ICollection<University> GetUniversities()
        {
            ICollection<University> universities;
            using (var db = new LibraryTestContext())
            {
                universities = db.Universities.ToList();
            }

            return universities;
        }

        [Route("universities/{id}")]
        public University GetByID(int id)
        {
            using (var db = new LibraryTestContext())
            {
                return db.Universities.FirstOrDefault(t => t.UniversityId == id);
            }
        }

        [Route("universities")]
        [HttpPost]
        public void Create(University university)
        {
            using (var db = new LibraryTestContext())
            {
                db.Universities.Add(university);
                db.SaveChanges();
            }
        }

        [Route("universities/{id}")]
        [HttpDelete]
        public void DeleteUniversity(int id)
        {
            using (var db = new LibraryTestContext())
            {
                var university = db.Universities.Where(t => t.UniversityId == id).FirstOrDefault();

                db.Entry(university).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        [Route("universities")]
        [HttpPut]
        public void UpdateUniversity(University updatedUniversity)
        {
            using (var db = new LibraryTestContext())
            {
                var university = db.Universities.Where(t => t.UniversityId == updatedUniversity.UniversityId).FirstOrDefault();

                if (university != null)
                {
                    university.Name = updatedUniversity.Name;
                    university.Address = updatedUniversity.Address;

                    db.SaveChanges();
                }
            }
        }
    }
}
