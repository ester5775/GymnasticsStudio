using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dal;
using DTO;
using System.Web.Http.Cors;

namespace GymnasticsStudioServer.Controllers
{
    //[Route("api/[controller]/{action}")]
    
    [RoutePrefix("api/Student")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        
        // GetStudentsList: api/Student
        [HttpGet]
        [Route("GetStudentsList")]
        public IEnumerable<StudentDTO> GetStudentsList()
        {
            ///במקום שליפה מהטבלה
            List<Student> studentsList = new List<Student>();
            studentsList.Add(new Student(1, "ester", "levco", "123456789", "0556730513","025375775",100));
            studentsList.Add(new Student(1, "david", "levco", "987654321", "0583221423", "029921423", 200));
            ///
            return StudentDTO.ConvertListToDTO(studentsList);
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
