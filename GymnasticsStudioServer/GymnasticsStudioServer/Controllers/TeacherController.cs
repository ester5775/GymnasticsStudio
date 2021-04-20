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
    
    [RoutePrefix("api/Teacher")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TeacherController : ApiController
    {
     
    }
}
