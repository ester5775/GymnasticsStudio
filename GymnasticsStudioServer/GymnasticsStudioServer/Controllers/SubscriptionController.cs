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

    [RoutePrefix("api/Subscription")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SubscriptionController : ApiController
    {
        // GetSubscriptionList: api/StudentInSubscription
        [HttpGet]
        [Route("GetSubscriptionList/{studentId}")]
        public IEnumerable<SubscriptionDTO> GetSubscriptionList(int studentId)
        {

            return SubscriptionFunction.GetSubscriptionList(studentId);
        }

    }
}
