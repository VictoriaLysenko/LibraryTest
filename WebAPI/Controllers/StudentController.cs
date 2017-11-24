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
    public class StudentController : ApiController
    {
        private readonly LibraryTestContext db;

        public StudentController()
        {
            db = new LibraryTestContext();
        }

        [Route("students")]
        public IEnumerable<Student> GetStudents()
        {
            return db.Students;
        }

        [Route("students/{id}")]
        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(t => t.StudentId == id);
        }

        [Route("students")]
        [HttpPut]
        public void CreateStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        [Route("students/{id}")]
        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var student = db.Students.Where(t => t.StudentId == id).FirstOrDefault();

            db.Entry(student).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        [Route("students")]
        [HttpPut]
        public void UpdateStudent(Student updatedStudent)
        {
            var student = db.Students.Where(t => t.StudentId == updatedStudent.StudentId).FirstOrDefault();

            if (student != null)
            {
                student.Surname = updatedStudent.Surname;
                student.Forename = updatedStudent.Forename;

                db.SaveChanges();
            }
        }
    }
}
