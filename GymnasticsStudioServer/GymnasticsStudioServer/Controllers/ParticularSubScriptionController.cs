
using Bll;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GymnasticsStudioServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ParticularSubscription")]
    public class ParticularSubScriptionController : ApiController
    {

        // AddStudentInSubscription: api/Student/5
        [HttpPut]
        [Route("AddParticularSubscription")]
        public IHttpActionResult AddParticularSubscription([FromBody] ParticularSubScriptionDTO particularSubScriptionDTO)
        {

            return Ok(ParticularSubscriptionFunction.AddParticularSubscription(particularSubScriptionDTO));
        }
    }
}
