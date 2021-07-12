using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentInSubscreptionDescriptionDTO
    {
        public int StudentInSubscreptionId { get; set; }
        public int SubscreptionId { get; set; }
        public string SubscreptionName { get; set; }
        public Nullable<double> SubscreptionPrice { get; set; }
    }
}
