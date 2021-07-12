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
    [RoutePrefix("api/Week")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class WeekController : ApiController
    {
        // POST: api/Week
        [HttpPost]
        [Route("EditWeek")]
        public IHttpActionResult Post([FromBody] WeekDTO Week)
        {
            return Ok(WeekFunction.EditWeek(Week));
        }

        // POST: api/Week
        [HttpPut]
        [Route("AddWeek")]
        public IHttpActionResult AddLesson([FromBody] WeekDTO Week)
        {
            return Ok(WeekFunction.AddWeek(Week));
        }


        // GetTWeekDetailsByWeekId: api/Week
        [HttpGet]
        [Route("GetWeekDetailsByWeekId/{id}")]
        public WeekDTO GetWeekDetailsByWeekId(int id)
        {
            return WeekFunction.GetWeekDetailsByWeekId(id);
        }


    }
}
