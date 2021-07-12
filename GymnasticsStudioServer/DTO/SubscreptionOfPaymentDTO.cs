using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SubscreptionOfPaymentDTO
    {
        public int PaymentId { get; set; }
        public double Sum { get; set; }
        public string StartDate { get; set; }
        public List<StudentInSubscreptionDescriptionDTO> StudentInSubscreptionDescriptionList { get; set; }



    }
}
