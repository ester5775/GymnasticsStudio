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
    }
}
