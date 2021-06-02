using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StudentInSubscripyionDetailsFunction
    {
        public static List<StudentInSubscriptionDetailsDTO> GetStudentInSubscripyionDetailsByStudentId(int studentId)
        {
            List<StudentInSubscriptionDetailsDTO> studentInSubscriptionDetailsDTOList = new List<StudentInSubscriptionDetailsDTO>();
            List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                studentInLessonList = GSDE.StudentInLessons.Where(x => x.StudentId == studentId).ToList();
                foreach (StudentInLesson studentInLesson in studentInLessonList)
                {
                    StudentInSubscriptionDetailsDTO studentInSubscriptionDetailsDTO = new StudentInSubscriptionDetailsDTO();
                    studentInSubscriptionDetailsDTO.WeehId = (int)studentInLesson.WeekId;
                    Week week = new Week();
                    week = GSDE.Weeks.Where(x => x.Id == studentInSubscriptionDetailsDTO.WeehId).FirstOrDefault();
                    studentInSubscriptionDetailsDTO.WeekStartDate = week.Date.ToString();
                    studentInSubscriptionDetailsDTO.WeekStartDate = ((DateTime)week.Date).AddDays(7).ToString();
                    studentInSubscriptionDetailsDTO.WeeklyPortion = week.WeeklyPortion;
                    studentInSubscriptionDetailsDTO.LessonId = (int)studentInLesson.LessonId;
                    Lesson lesson = new Lesson();
                    lesson = GSDE.Lessons.Where(x => x.Id == studentInSubscriptionDetailsDTO.LessonId).FirstOrDefault();
                    studentInSubscriptionDetailsDTO.LessonName = lesson.Name;
                    studentInSubscriptionDetailsDTO.LessonDay = lesson.Day;
                    studentInSubscriptionDetailsDTO.LessonStartHower = lesson.StartHower;
                    studentInSubscriptionDetailsDTO.LessonFinishHower = lesson.FinishHower;
                    studentInSubscriptionDetailsDTO.Attendance = studentInLesson.Attendance;
                    studentInSubscriptionDetailsDTO.SubscriptionId= (int)GSDE.StudentInSubscriptions.Where(x => x.Id == studentInLesson.StudentInSubscriptionId).First().SubscribtionId;
                    Subscription subscription = new Subscription();
                    subscription = GSDE.Subscriptions.Where(x => x.Id == studentInSubscriptionDetailsDTO.SubscriptionId).First();
                    studentInSubscriptionDetailsDTO.SubscriptionName = subscription.Name;
                    studentInSubscriptionDetailsDTO.PaymentId = (int)studentInLesson.PaymentId;
                    Payment payment = new Payment();
                    payment = GSDE.Payments.Where(x => x.Id == studentInSubscriptionDetailsDTO.PaymentId).First();
                    studentInSubscriptionDetailsDTO.PaymentStartDate = payment.StartDate.ToString();
                    studentInSubscriptionDetailsDTO.PaymentFinishDate = payment.FinishDate.ToString();
                    studentInSubscriptionDetailsDTO.PaymentSum = payment.Sum;
                    Student student = new Student();
                    student = GSDE.Students.Where(x => x.Id == studentId).First();
                    studentInSubscriptionDetailsDTO.Balance = student.Balance;
                    studentInSubscriptionDetailsDTOList.Add(studentInSubscriptionDetailsDTO);


                }

            }
            return studentInSubscriptionDetailsDTOList;
        }

    }
}
