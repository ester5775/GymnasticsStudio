

using Bll;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GymnasticsStudioServer.Controllers
{
    //[Route("api/[controller]/{action}")]

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        
        // GetStudentsList: api/Student
        [HttpGet]
        [Route("GetStudentsList")]
        public IEnumerable<StudentDTO> GetStudentsList()
        {

            return StudentFunction.GetStudentsList();
        }

        
        // GetStudentsListByKind: api/Student
        [HttpGet]
        [Route("GetStudentsListByKind/{studentKind}")]
        public IEnumerable<StudentDTO> GetStudentsListByKind(string studentKind)
        {

            return StudentFunction.GetStudentsListByKind(studentKind);
        }



        // POST: api/Student
        [HttpPost]
        [Route("EditStudent")]
        public IHttpActionResult Post([FromBody] StudentDTO student)
        {
            return Ok(StudentFunction.EditStudent(student));
        }

        // AddStudent: api/Student
        [HttpPut]
        [Route("AddStudent")]
        public IHttpActionResult AddStudent([FromBody] StudentDTO student)
        {
            return Ok(StudentFunction.AddStudent(student));
        }

        // GetStudentsList: api/Student
        [HttpPost]
        [Route("GetStudentsListByDetails")]
        public IEnumerable<StudentDTO> GetStudentsListByDetails([FromBody]StudentDTO student)
        {

            return StudentFunction.GetStudentsListByDetails(student);
        }


        // GetStudentDetailsByStudentId: api/Student/5
        [HttpGet]
        [Route("GetStudentDetailsByStudentId/{id}")]
        public StudentDTO GetStudentDetailsByStudentId(int id)
        {
            return StudentFunction.GetStudentDetailsByStudentId(id);
        }


        // GetBalance: api/Student/5
        [HttpGet]
        [Route("GetBalance/{id}")]
        public int GetBalance(int id)
        {
            return StudentFunction.GetBalance(id);
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
