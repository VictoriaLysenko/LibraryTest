using Models.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class UniversityController : Controller
    {
        private RestClient client;
        // GET: University
        public string Index()
        {
            return "University";
        }

        public UniversityController()
        {
            client = new RestClient("http://localhost:49361/");
        }

        public ActionResult GetUniversities()
        {
            RestRequest request = new RestRequest("api/universities", Method.GET) { RequestFormat = DataFormat.Json };
            IRestResponse<List<University>> response = client.Execute<List<University>>(request);
            return View(response.Data);
        }

        public ActionResult Details(int id)
        {
            RestRequest request = new RestRequest("api/universities/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            IRestResponse<University> response = client.Execute<University>(request);

            return View(response.Data);
        }

        public ActionResult Create(University university)
        {
            if (university.UniversityId != 0)
            {
                RestRequest request = new RestRequest("api/universities", Method.POST);
                request.AddObject(university);
                IRestResponse response = client.Execute(request);
            }

            return View(university);
        }
        public ActionResult Delete(int id)
        {
            RestRequest request = new RestRequest("api/universities/{id}", Method.DELETE);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            IRestResponse response = client.Execute(request);
            return RedirectToAction("GetUniversities");
        }

        public ActionResult Put(int id, University university)
        {
            RestRequest request1 = new RestRequest("api/universities/{id}", Method.GET);
            request1.AddParameter("id", id, ParameterType.UrlSegment);

            IRestResponse<University> response1 = client.Execute<University>(request1);

            RestRequest request = new RestRequest("api/universities", Method.PUT);
            request.AddObject(university);
            IRestResponse response = client.Execute(request);
            return View(response1.Data);
        }
    }
}