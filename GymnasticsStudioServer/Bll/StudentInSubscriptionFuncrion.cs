using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StudentInSubscriptionFuncrion
    {

        public static List<StudentInSubscriptionDTO> GetStudentInSubscriptionListByStudentId(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<List<StudentInSubscriptionDTO>> studentInSubscriptionListsList = new List<List<StudentInSubscriptionDTO>>();
                List<StudentInSubscription> studentInSubscriptionList = new List<StudentInSubscription>();
                List<Payment> paymentList = PaymentDTO.ConvertListFromDTO(PaymentFunction.GetStudentPaymentsList(studentId));
                foreach (Payment payment in paymentList)
                {
                    studentInSubscriptionList = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate < payment.StartDate).ToList();
                    studentInSubscriptionListsList.Add(StudentInSubscriptionDTO.ConvertListToDTO(studentInSubscriptionList));
                }
                return StudentInSubscriptionDTO.ConvertListToDTO(studentInSubscriptionList);
            }


        }
        public static List<string> GetStudentInSubscriptionNamesListByStudentId(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<List<StudentInSubscriptionDTO>> studentInSubscriptionListsList = new List<List<StudentInSubscriptionDTO>>();
                List<StudentInSubscription> studentInSubscriptionList = new List<StudentInSubscription>();
                List<string> subscriptionNameList = new List<string>();
                List<Payment> paymentList = PaymentDTO.ConvertListFromDTO(PaymentFunction.GetStudentPaymentsList(studentId));
                foreach (Payment payment in paymentList)
                {
                    studentInSubscriptionList = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && (x.StartDate > payment.StartDate && x.StartDate < payment.FinishDate || x.FinishDate < payment.FinishDate && x.FinishDate > payment.StartDate)).ToList();
                    foreach (StudentInSubscription studentInSubscription in studentInSubscriptionList)
                    {
                        subscriptionNameList.Add(GSDE.Subscriptions.FirstOrDefault(x => x.Id == studentInSubscription.Id).Name);
                    }
                    studentInSubscriptionListsList.Add(StudentInSubscriptionDTO.ConvertListToDTO(studentInSubscriptionList));
                }
                return subscriptionNameList;
            }
        }

    }    
}
