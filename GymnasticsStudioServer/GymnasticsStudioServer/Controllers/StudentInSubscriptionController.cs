
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

    [RoutePrefix("api/StudentInSubscription")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class StudentInSubscriptionController : ApiController
    {

        // GetStudentInSubscriptionListStudentId: api/StudentInSubscription
        [HttpGet]
        [Route("GetStudentInSubscriptionListByStudentId/{studentId}")]
        public IEnumerable<StudentInSubscriptionDTO> GetStudentInSubscriptionListByStudentId(int studentId)
        {

            return ParticularSubscriptionFuncrion.GetStudentInSubscriptionListByStudentId(studentId);
        }

        // GetStudentInSubscriptionListStudentId: api/StudentInSubscription
        [HttpGet]
        [Route("GetStudentInSubscriptionNamesListByStudentId/{studentId}")]
        public IEnumerable<List<string>> GetStudentInSubscriptionNamesListByStudentId(int studentId)
        {

            return ParticularSubscriptionFuncrion.GetStudentInSubscriptionNamesListByStudentId(studentId);
        }


        // GetCurrentSubscription: api/StudentInSubscription
        [HttpGet]
        [Route("GetCurrentSubscription/{studentId}")]
        public SubscriptionDTO GetCurrentSubscription(int studentId)
        {

            return ParticularSubscriptionFuncrion.GetCurrentSubscription(studentId);
        }



        // GetCurrentStudentInSubscription: api/StudentInSubscription
        [HttpGet]
        [Route("GetCurrentStudentInSubscription/{studentId}")]
        public StudentInSubscriptionDTO GetCurrentStudentInSubscription(int studentId)
        {

            return ParticularSubscriptionFuncrion.GetCurrentStudentInSubscription(studentId);
        }


        // GetCurrentWeekNum: api/StudentInSubscription
        [HttpGet]
        [Route("GetCurrentWeekNum/{studentId}")]
        public int GetCurrentWeekNum(int studentId)
        {

            return ParticularSubscriptionFuncrion.GetCurrentWeekNum(studentId);
        }


        // POST: api/Student
        [HttpPost]
        [Route("EditStudentInSubscription")]
        public IHttpActionResult EditStudentInSubscription([FromBody] StudentInSubscriptionDTO studentInSubscription)
        {
            return Ok(ParticularSubscriptionFuncrion.EditStudentInSubscription(studentInSubscription));
        }



        // AddStudentInSubscription: api/Student/5
        [HttpPut]
        [Route("AddStudentInSubscription")]
        public IHttpActionResult AddStudentInSubscription([FromBody] StudentInSubscriptionDTO studentInSubscription)
        {

            return Ok(ParticularSubscriptionFuncrion.AddStudentInSubscription(studentInSubscription));
        }
    }
}
