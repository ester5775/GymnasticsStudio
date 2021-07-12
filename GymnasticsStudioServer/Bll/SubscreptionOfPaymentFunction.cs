using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class SubscreptionOfPaymentFunction
    {
        public static List<SubscreptionOfPaymentDTO> GetSubscreptionOfPaymentListByStudentId(int studentId)
        {
         
               
                   
            List<SubscreptionOfPaymentDTO> SubscreptionOfPaymentDTOList = new List<SubscreptionOfPaymentDTO>();
            List<Payment> paymentsList = new List<Payment>();
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                paymentsList = GSDE.Payments.Where(x => x.StudentId == studentId).ToList();
            foreach (Payment payment in paymentsList)
                {
                    SubscreptionOfPaymentDTO subscreptionOfPaymentDTO = new SubscreptionOfPaymentDTO();
                    subscreptionOfPaymentDTO.PaymentId = payment.Id;
                    subscreptionOfPaymentDTO.Sum = (int)payment.Sum;
                    subscreptionOfPaymentDTO.StartDate = payment.StartDate.ToString();
                    subscreptionOfPaymentDTO.StudentInSubscreptionDescriptionList = StudentInSubscreptionDescriptionFunction.GetStudentInSubscreptionDescriptionDTOByPaymentId(payment.Id);
                    SubscreptionOfPaymentDTOList.Add(subscreptionOfPaymentDTO);
                }
                
            }
            return SubscreptionOfPaymentDTOList;

        }
        }

    }

