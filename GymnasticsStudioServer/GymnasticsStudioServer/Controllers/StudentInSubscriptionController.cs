<<<<<<< HEAD
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
        public IEnumerable<string> GetStudentInSubscriptionNamesListByStudentId(int studentId)
        {

            return StudentInSubscriptionFuncrion.GetStudentInSubscriptionNamesListByStudentId(studentId);
        }

        
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DTO;
using System.Web.Http.Cors;

namespace GymnasticsStudioServer.Controllers
{
    //[Route("api/[controller]/{action}")]

    [RoutePrefix("api/StudentInSubscription")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class StudentInSubscriptionController : ApiController
    {
    }
>>>>>>> 3442e087c25f22a2f2188e4e8c8aa6d2ac058232
}