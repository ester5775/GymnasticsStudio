using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentInSubscriptionDetailsListDTO
    {
        public string StudentName { get; set; }
        public List<StudentInSubscriptionDetailsDTO> studentInSubscriptionDetailsDTOList  { get; set; }
    }
}
