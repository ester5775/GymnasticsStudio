using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StudentInSubscreptionDescriptionFunction
    {
        public static List<StudentInSubscreptionDescriptionDTO> GetStudentInSubscreptionDescriptionDTOByPaymentId(int paymentId)
        {
            List<StudentInSubscreptionDescriptionDTO> studentInSubscreptionDescriptionDTOList = new List<StudentInSubscreptionDescriptionDTO>();
            List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
            List<StudentInSubscription> studentInSubscriptionList = new List<StudentInSubscription>();
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                studentInLessonList = GSDE.StudentInLessons.Where(x => x.PaymentId == paymentId).ToList();
                foreach (StudentInLesson studentInLesson in studentInLessonList)
                {                    
                    studentInSubscriptionList.AddRange(GSDE.StudentInSubscriptions.Where(x=>x.Id==studentInLesson.StudentInSubscriptionId).ToList());
                }
                studentInSubscriptionList=studentInSubscriptionList.Distinct().ToList();
                foreach (StudentInSubscription studentInSubscription in studentInSubscriptionList)
                {
                    StudentInSubscreptionDescriptionDTO studentInSubscreptionDescriptionDTO = new StudentInSubscreptionDescriptionDTO();
                    studentInSubscreptionDescriptionDTO.StudentInSubscreptionId = studentInSubscription.Id;                    
                    studentInSubscreptionDescriptionDTO.SubscreptionId = (int)studentInSubscription.SubscribtionId;
                    Subscription subscription = new Subscription();
                    subscription = GSDE.Subscriptions.Where(x => x.Id == studentInSubscreptionDescriptionDTO.SubscreptionId).First();
                    studentInSubscreptionDescriptionDTO.SubscreptionName = subscription.Name;
                    studentInSubscreptionDescriptionDTO.SubscreptionPrice =  subscription.Price;
                    studentInSubscreptionDescriptionDTOList.Add(studentInSubscreptionDescriptionDTO);
                }
                return studentInSubscreptionDescriptionDTOList;


            }
        }

    }
}
