using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DTO;
using System.Web.Http.Cors;
using Bll;

namespace GymnasticsStudioServer.Controllers
{
    //[Route("api/[controller]/{action}")]
    
    [RoutePrefix("api/Lesson")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LessonController : ApiController
    {
        // GetLessonsListBySubscriptionByStudentIdEndDate: api/Lesson
        [HttpGet]
        [Route("GetLessonsListBySubscriptionByStudentIdEndDate/{studentId}/{date}")]
        public IEnumerable<LessonDTO> GetLessonsListBySubscriptionByStudentIdEndDate(int studentId,string date)
        {

            return LessonFunction.GetLessonsListBySubscriptionByStudentIdEndDate(studentId,date);
        }




        // GetLessonListByvKind: api/Lesson
        [HttpGet]
        [Route("GetLessonListByLessonKind/{lessonKind}")]
        public IEnumerable<LessonDTO> GetLessonListByLessonKind(string lessonKind)
        {
            return LessonFunction.GetLessonListByLessonKind(lessonKind);
        }

        // POST: api/Student
        [HttpPost]
        [Route("EditLesson")]
        public IHttpActionResult Post([FromBody] LessonDTO Lesson)
        {
            return Ok(LessonFunction.EditLesson(Lesson));
        }

        // POST: api/Student
        [HttpPut]
        [Route("AddLesson")]
        public IHttpActionResult AddLesson([FromBody] LessonDTO Lesson)
        {
            return Ok(LessonFunction.AddLesson(Lesson));
        }


        // GetTLessonDetailsByLessonId: api/Lesson
        [HttpGet]
        [Route("GetLessonDetailsByLessonId/{id}")]
        public LessonDTO GetLessonDetailsByLessonId(int id)
        {
            return LessonFunction.GetLessonDetailsByLessonId(id);
        }



        // getLessonList: api/Lesson
        [HttpGet]
        [Route("getLessonList")]
        public IEnumerable<LessonDTO> getLessonList()
        {

            return LessonFunction.getLessonList();
        }
    }
}