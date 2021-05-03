using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class LessonFunction
    {
        
        public static List<LessonDTO> GetLessonsListBySubscriptionByStudentIdEndDate(int studentId,string date)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {

                List<Lesson> LessonList = new List<Lesson>();
                DateTime Date = Convert.ToDateTime(date);
                StudentInSubscription studentInSubscription = new StudentInSubscription();
                studentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= Date && x.FinishDate >= Date).FirstOrDefault();
                Subscription subscriptin = new Subscription();
                if (studentInSubscription == default)
                    return null;
                 subscriptin = GSDE.Subscriptions.Where(x => x.Id == studentInSubscription.SubscribtionId).FirstOrDefault();         
                var subscription= GSDE.Subscriptions.Where(x => x.Id == subscriptin.Id).FirstOrDefault();
                if (subscriptin.LessonKind == default)
                    return null;
                string lessonKind = subscriptin.LessonKind;                  
                LessonList = GSDE.Lessons.Where(x => x.LessonKind == lessonKind).ToList();
                
                return LessonDTO.ConvertListToDTO(LessonList);
            }
        }

    }
}
