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
        // getSubscriptionListByStudent: api/StudentInSubscription
        [HttpGet]
        [Route("getSubscriptionListByStudent/{studentId}")]
        public IEnumerable<SubscriptionDTO> getSubscriptionListByStudent(int studentId)
        {

            return SubscriptionFunction.getSubscriptionListByStudent(studentId);
        }

    


    // POST: api/Subscription
    [HttpPost]
    [Route("EditSubscription")]
    public IHttpActionResult EditSubscription([FromBody] SubscriptionDTO Subscription)
    {
        return Ok(SubscriptionFunction.EditSubscription(Subscription));
    }

        // AddSubscription: api/Subscription
        [HttpPut]
    [Route("AddSubscription")]
    public IHttpActionResult AddSubscription([FromBody] SubscriptionDTO Subscription)
    {
        return Ok(SubscriptionFunction.AddSubscription(Subscription));
    }


        // GetSubscriptionDetailsBySubscriptionId: api/Teacher
        [HttpGet]
    [Route("GetSubscriptionDetailsBySubscriptionId/{id}")]
    public SubscriptionDTO GetSubscriptionDetailsBySubscriptionId(int id)
    {
        return SubscriptionFunction.GetSubscriptionDetailsBySubscriptionId(id);
    }



        // getSubscriptionList: api/Subscription
        [HttpGet]
    [Route("getSubscriptionList")]
    public IEnumerable<SubscriptionDTO> getSubscriptionList()
    {

        return SubscriptionFunction.getSubscriptionList();
    }
}
}

