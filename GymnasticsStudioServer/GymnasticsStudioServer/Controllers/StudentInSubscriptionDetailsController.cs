
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

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/StudentInSubscriptionDetails")]
    public class StudentInSubscriptionDetailsController : ApiController
    {

        // GetStudentInSubscriptionDetailsListListBystudentKind: api/StudentInSubscriptionDetails
        [HttpGet]
        [Route("GetStudentInSubscriptionDetailsListListBystudentKind/{studentKind}")]
        public IEnumerable<StudentInSubscriptionDetailsListDTO> GetStudentInSubscriptionDetailsListListBystudentKind(string studentKind)
        {
            return StudentInSubscriptionDetailsListFunction.GetStudentInSubscriptionDetailsListListBystudentKind(studentKind);
        }

    }
}
