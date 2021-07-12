

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

        [HttpGet]
        [Route("GetSubscreptionOfPaymentListByStudentId/{Id}")]
        public IEnumerable<SubscreptionOfPaymentDTO> GetSubscreptionOfPaymentListByStudentId(int id)
        {

            return SubscreptionOfPaymentFunction.GetSubscreptionOfPaymentListByStudentId(id);
        }

        // POST: api/Payment
        [HttpPut]
        [Route("AddPayment")]
        public IHttpActionResult AddPayment([FromBody] PaymentDTO Payment)
        {
            return Ok(PaymentFunction.AddPayment(Payment));
        }


        // GetTPaymentDetailsByPaymentId: api/Week
        [HttpGet]
        [Route("GetPaymentDetailsByPaymentId/{id}")]
        public PaymentDTO GetPaymentDetailsByPaymentId(int id)
        {
            return PaymentFunction.GetPaymentDetailsByPaymentId(id);
        }


    }
}