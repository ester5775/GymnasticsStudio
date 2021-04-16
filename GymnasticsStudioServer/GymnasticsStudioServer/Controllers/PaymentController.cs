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
    
    [RoutePrefix("api/Payment")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("GetPaymentsListByStudentId/{Id}")]
        public IEnumerable<PaymentDTO> GetPaymentsListByStudentId(int id)
        {

            return PaymentFunction.GetStudentPaymentsList(id);
        }


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
    
    [RoutePrefix("api/Payment")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PaymentController : ApiController
    {
     
    }
}
>>>>>>> 3442e087c25f22a2f2188e4e8c8aa6d2ac058232
