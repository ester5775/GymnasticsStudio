﻿using System.Collections.Generic;
using System.Web.Http;
using DTO;
using System.Web.Http.Cors;
using Bll;

namespace GymnasticsStudioServer.Controllers
{
    //[Route("api/[controller]/{action}")]

    [RoutePrefix("api/Student")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {

        // GetStudentsList: api/Student
        [HttpGet]
        [Route("GetStudentsList")]
        public IEnumerable<StudentDTO> GetStudentsList()
        {

            return StudentFunction.GetStudentsList();
        }

        // GET: api/Student/5
        [HttpGet]
        [Route("GetStudent")]
        public IHttpActionResult GetStudent(int id)
        {
            return Ok(StudentFunction.GetStudentById(id));
        }

        // POST: api/Student
        [HttpPost]
        [Route("EditStudent")]
        public IHttpActionResult Post([FromBody]StudentDTO student)
        {
            return Ok(StudentFunction.EditStudent(student));
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
