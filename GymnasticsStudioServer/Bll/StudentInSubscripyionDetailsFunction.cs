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
            List<StudentInSubscriptionDetailsDTO> StudentInSubscriptionDetailsDTOList = new List<StudentInSubscriptionDetailsDTO>();
            List<Week> weekList = new List<Week>();
            List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                weekList = GSDE.Weeks.ToList();

                foreach (Week week in weekList)
                {
                    DateTime finishDate = (Convert.ToDateTime(week.Date)).AddDays(7);
                    studentInLessonList = GSDE.StudentInLessons.Where( x => x.StudentId == studentId && x.Date > week.Date&& x.Date <finishDate).ToList();
                    if(studentInLessonList.Count()==0)
                    {
                        StudentInSubscriptionDetailsDTO studentInSubscriptionDetailsDTO = new StudentInSubscriptionDetailsDTO();
                        studentInSubscriptionDetailsDTO.WeehId = week.Id;
                        studentInSubscriptionDetailsDTO.WeekStartDate = week.Date.ToString();
                        studentInSubscriptionDetailsDTO.WeekFinishDate = ((DateTime)week.Date).AddDays(7).ToString();
                        studentInSubscriptionDetailsDTO.WeeklyPortion = week.WeeklyPortion;
                        
                       
                        StudentInSubscriptionDetailsDTOList.Add(studentInSubscriptionDetailsDTO);
                    }

                    foreach (StudentInLesson studentInLesson in studentInLessonList)
                    {
                       

                        StudentInSubscriptionDetailsDTO studentInSubscriptionDetailsDTO = new StudentInSubscriptionDetailsDTO();
                        studentInSubscriptionDetailsDTO.WeehId = week.Id;
                        studentInSubscriptionDetailsDTO.WeekStartDate = week.Date.ToString();
                        studentInSubscriptionDetailsDTO.WeekFinishDate = ((DateTime)week.Date).AddDays(7).ToString();
                        studentInSubscriptionDetailsDTO.WeeklyPortion = week.WeeklyPortion;
                        studentInSubscriptionDetailsDTO.StudentInLessonId = (int)studentInLesson.Id;
                        studentInSubscriptionDetailsDTO.StudntId = (int)studentInLesson.StudentId;
                        studentInSubscriptionDetailsDTO.LessonId = (int)studentInLesson.LessonId;
                        Lesson lesson = new Lesson();
                        lesson = GSDE.Lessons.Where(x => x.Id == studentInSubscriptionDetailsDTO.LessonId).FirstOrDefault();
                        studentInSubscriptionDetailsDTO.LessonName = lesson.Name;
                        studentInSubscriptionDetailsDTO.LessonDay = lesson.Day;
                        studentInSubscriptionDetailsDTO.LessonStartHower = lesson.StartHower;
                        studentInSubscriptionDetailsDTO.LessonFinishHower = lesson.FinishHower;
                        studentInSubscriptionDetailsDTO.Attendance = studentInLesson.Attendance;
                        studentInSubscriptionDetailsDTO.SubscriptionId = (int)GSDE.StudentInSubscriptions.Where(x => x.Id == studentInLesson.StudentInSubscriptionId).First().SubscribtionId;
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
                        StudentInSubscriptionDetailsDTOList.Add(studentInSubscriptionDetailsDTO);


                    }
                    
                }

            }
            return StudentInSubscriptionDetailsDTOList;
        }

    }
}
