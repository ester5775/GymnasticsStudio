
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
    
    [RoutePrefix("api/Teacher")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TeacherController : ApiController
    {
        
        // GetTeacherNameList: api/Student
        [HttpPost]
        [Route("GetTeacherNameList")]
        public IEnumerable<string> GetTeacherNameList([FromBody]List<int> teacherIdList)
        {

            return TeacherFunction.GetTeacherNameList(teacherIdList);
        }


        // POST: api/Student
        [HttpPost]
        [Route("EditTeacher")]
        public IHttpActionResult Post([FromBody] TeacherDTO teacher)
        {
            return Ok(TeacherFunction.EditTeacher(teacher));
        }

        // POST: api/Student
        [HttpPut]
        [Route("AddTeacher")]
        public IHttpActionResult AddTeacher([FromBody] TeacherDTO teacher)
        {
            return Ok(TeacherFunction.AddTeacher(teacher));
        }


        // GetTeacherDetailsByTeacherId: api/Teacher
        [HttpGet]
        [Route("GetTeacherDetailsByTeacherId/{id}")]
        public TeacherDTO GetTeacherDetailsByTeacherId(int id)
        {
            return TeacherFunction.GetTeacherDetailsByTeacherId(id);
        }



        // getTeacherList: api/Taecher
        [HttpGet]
        [Route("getTeacherList")]
        public IEnumerable<TeacherDTO> getTeacherList()
        {

            return TeacherFunction.getTeacherList();
        }
    }
}
