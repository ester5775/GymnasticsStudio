
﻿using System;
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

        // GetCurrentWeekNum: api/StudentInSubscription
        [HttpGet]
        [Route("GetCurrentWeekNum/{studentId}")]
        public int GetCurrentWeekNum(int studentId)
        {

            return StudentInSubscriptionFuncrion.GetCurrentWeekNum(studentId);
        }
        

    }
}
