
﻿using Dal;
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
                CurrentstudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= DateTime.Now && x.FinishDate>=DateTime.Now).FirstOrDefault();
                Subscription currentSubscriptin = new Subscription();
                if (CurrentstudentInSubscription != default)
                    currentSubscriptin = GSDE.Subscriptions.Where(x => x.Id == CurrentstudentInSubscription.SubscribtionId).FirstOrDefault();
                else
                    currentSubscriptin = null;
                return SubscriptionDTO.ConvertToDTO(currentSubscriptin);
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
    }
}