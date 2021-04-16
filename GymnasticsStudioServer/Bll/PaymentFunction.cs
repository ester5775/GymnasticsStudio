

using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class PaymentFunction
    {

        public static List<PaymentDTO> GetStudentPaymentsList(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Payment> paymentList = new List<Payment>();
                paymentList = GSDE.Payments.Where(x=>x.StudentId==studentId).ToList();
                return PaymentDTO.ConvertListToDTO(paymentList);


            }
        }
    }
}
