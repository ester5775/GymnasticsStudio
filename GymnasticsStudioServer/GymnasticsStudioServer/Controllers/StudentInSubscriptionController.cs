

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

            return StudentInSubscriptionFuncrion.GetStudentInSubscriptionListByStudentId(studentId);
        }

        // GetStudentInSubscriptionListStudentId: api/StudentInSubscription
        [HttpGet]
        [Route("GetStudentInSubscriptionNamesListByStudentId/{studentId}")]
        public IEnumerable<List<string>> GetStudentInSubscriptionNamesListByStudentId(int studentId)
        {

            return StudentInSubscriptionFuncrion.GetStudentInSubscriptionNamesListByStudentId(studentId);
        }


        // GetCurrentSubscription: api/StudentInSubscription
        [HttpGet]
        [Route("GetCurrentSubscription/{studentId}")]
        public SubscriptionDTO GetCurrentSubscription(int studentId)
        {

            return StudentInSubscriptionFuncrion.GetCurrentSubscription(studentId);
        }



        // GetCurrentStudentInSubscription: api/StudentInSubscription
        [HttpGet]
        [Route("GetCurrentStudentInSubscription/{studentId}")]
        public StudentInSubscriptionDTO GetCurrentStudentInSubscription(int studentId)
        {

            return StudentInSubscriptionFuncrion.GetCurrentStudentInSubscription(studentId);
        }


        // GetCurrentWeekNum: api/StudentInSubscription
        [HttpGet]
        [Route("GetCurrentWeekNum/{studentId}")]
        public int GetCurrentWeekNum(int studentId)
        {

            return StudentInSubscriptionFuncrion.GetCurrentWeekNum(studentId);
        }


        // POST: api/StudentInSubscription
        [HttpPost]
        [Route("EditStudentInSubscription")]
        public IHttpActionResult EditStudentInSubscription([FromBody] StudentInSubscriptionDTO studentInSubscription)
        {
            return Ok(StudentInSubscriptionFuncrion.EditStudentInSubscription(studentInSubscription));
        }



        // AddStudentInSubscription: api/StudentInSubscription
        [HttpPut]
        [Route("AddStudentInSubscription")]
        public IHttpActionResult AddStudentInSubscription([FromBody] StudentInSubscriptionDTO studentInSubscription)
        {

            return Ok(StudentInSubscriptionFuncrion.AddStudentInSubscription(studentInSubscription));
        }


        // AddStudentInSubscriptionUpToNow: api/StudentInSubscription
        [HttpGet]
        [Route("AddStudentInSubscriptionUpToNow/{studentId}")]
        public IHttpActionResult AddStudentInSubscriptionUpToNow(int studentId)
        {

            return Ok(StudentInSubscriptionFuncrion.AddStudentInSubscriptionUpToNow(studentId));
        }


        // AddStudentInSubscriptionUpToNowForEvryStudent: api/StudentInSubscription
        [HttpGet]
        [Route("AddStudentInSubscriptionUpToNowForEvryStudent")]
        public IHttpActionResult AddStudentInSubscriptionUpToNowForEvryStudent()
        {

            return Ok(StudentInSubscriptionFuncrion.AddStudentInSubscriptionUpToNowForEvryStudent());
        }

        // EditSubscription: api/StudentInSubscription
        [HttpGet]
        [Route("EditSubscription/{CurrentStudentInSubscriptionId}/{subscriptionId}")]
        public IHttpActionResult EditSubscription(int CurrentStudentInSubscriptionId,int subscriptionId)
        {

            return Ok(StudentInSubscriptionFuncrion.EditSubscription(CurrentStudentInSubscriptionId,subscriptionId));
        }



        // CreateStudentInSubscription: api/StudentInSubscription
        [HttpPost]
        [Route("CreateStudentInSubscription")]
        public IHttpActionResult CreateStudentInSubscription([FromBody] StudentInSubscriptionDTO studentInSubscription)
        {

            return Ok(StudentInSubscriptionFuncrion.CreateStudentInSubscription(studentInSubscription));
        }



        // StopSubscriptionByDate: api/StudentInSubscription
        [HttpGet]
        [Route("StopSubscriptionByDate/{date}")]
        public IHttpActionResult StopSubscriptionByDate(string date)
        {

            return Ok(StudentInSubscriptionFuncrion.StopSubscriptionByDate(date));
        }


    }
}
