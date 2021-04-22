
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
        public static List<List<string>> GetStudentInSubscriptionNamesListByStudentId(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<List<StudentInSubscriptionDTO>> studentInSubscriptionListsList = new List<List<StudentInSubscriptionDTO>>();
                List<StudentInSubscription> studentInSubscriptionList = new List<StudentInSubscription>();
                List<List<string>> subscriptionNameList = new List<List<string>>();
                List<Payment> paymentList = PaymentDTO.ConvertListFromDTO(PaymentFunction.GetStudentPaymentsList(studentId));
                int i = -1;
                foreach (Payment payment in paymentList)
                {
                    i++;
                    studentInSubscriptionList = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && (x.StartDate > payment.StartDate && x.StartDate < payment.FinishDate || x.FinishDate < payment.FinishDate && x.FinishDate > payment.StartDate)).ToList();
                    for (int j = 0; j < studentInSubscriptionList.Count(); j++)

                    {
                        subscriptionNameList[i].Add(GSDE.Subscriptions.FirstOrDefault(x => x.Id == studentInSubscriptionList[j].Id).Name);
                    }
                    studentInSubscriptionListsList.Add(StudentInSubscriptionDTO.ConvertListToDTO(studentInSubscriptionList));

                }
                return subscriptionNameList;
            }
        }




        public static SubscriptionDTO GetCurrentSubscription(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                StudentInSubscription CurrentstudentInSubscription = new StudentInSubscription();
                CurrentstudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= DateTime.Now && x.FinishDate >= DateTime.Now).FirstOrDefault();
                Subscription currentSubscriptin = new Subscription();
                if (CurrentstudentInSubscription != default)
                    currentSubscriptin = GSDE.Subscriptions.Where(x => x.Id == CurrentstudentInSubscription.SubscribtionId).FirstOrDefault();
                else
                    currentSubscriptin = null;
                return SubscriptionDTO.ConvertToDTO(currentSubscriptin);
            }


        }



        public static StudentInSubscriptionDTO GetCurrentStudentInSubscription(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                StudentInSubscription CurrentstudentInSubscription = new StudentInSubscription();
                CurrentstudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= DateTime.Now && x.FinishDate >= DateTime.Now).FirstOrDefault();
                return StudentInSubscriptionDTO.ConvertToDTO(CurrentstudentInSubscription);
            }


        }

        public static int GetCurrentWeekNum(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                int num;
                StudentInSubscription CurrentstudentInSubscription = new StudentInSubscription();
                CurrentstudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= DateTime.Now && x.FinishDate >= DateTime.Now).FirstOrDefault();
                if (CurrentstudentInSubscription.StartDate != null)
                {
                    var d = (DateTime.Now - (DateTime)CurrentstudentInSubscription.StartDate);
                    num = (int)(DateTime.Now - (DateTime)CurrentstudentInSubscription.StartDate).Days / 7;
                }
                else num = 0;
                return num;
            }


        }



        public static bool EditStudentInSubscription(StudentInSubscriptionDTO studentInSubscription)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {

                    var s = context.StudentInSubscriptions.FirstOrDefault(x => x.Id == studentInSubscription.Id);
                    if (s != null)
                    {
                        s.Id = studentInSubscription.Id;
                        s.StudentId = studentInSubscription.StudentId;
                        s.SubscribtionId = studentInSubscription.SubscribtionId;
                        s.StartDate = Convert.ToDateTime(studentInSubscription.StartDate);
                        s.FinishDate = Convert.ToDateTime(studentInSubscription.FinishDate);
                        context.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public static bool AddStudentInSubscription(StudentInSubscriptionDTO studentInSubscriptionDTO)
        {
           
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    
                    StudentInSubscription studentInSubscription = StudentInSubscriptionDTO.ConvertFromDTO(studentInSubscriptionDTO);
                    Subscription subscription = GSDE.Subscriptions.Where(x => x.Id == studentInSubscription.SubscribtionId).FirstOrDefault();

         
         

                          if (studentInSubscription != default)
                    {
                        Convert.ToDateTime(studentInSubscription.StartDate);
                        studentInSubscription.FinishDate = studentInSubscription.StartDate;
                        studentInSubscription.FinishDate=Convert.ToDateTime(studentInSubscription.FinishDate).AddDays(7 * (double)subscription.WeeksNum);
                    }
                    var lastStudentInSubscriptions = GSDE.StudentInSubscriptions.Where(x => x.StartDate == studentInSubscription.StartDate).FirstOrDefault();
                    if (lastStudentInSubscriptions != default)
                    {
                        studentInSubscription.Id = lastStudentInSubscriptions.Id;
                        return EditStudentInSubscription(StudentInSubscriptionDTO.ConvertToDTO(studentInSubscription));
                    }

                    GSDE.StudentInSubscriptions.Add(studentInSubscription);
                    GSDE.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}