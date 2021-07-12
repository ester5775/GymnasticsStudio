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

        public static List<LessonDTO> GetLessonListByLessonKind(string lessonKind)
        {
            List<Lesson> LessonList = new List<Lesson>();
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    LessonList = GSDE.Lessons.Where(x => x.LessonKind == lessonKind).ToList();
                }
                return LessonDTO.ConvertListToDTO(LessonList);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
        public static LessonDTO GetLessonDetailsByLessonId(int id)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                Lesson Lesson = new Lesson();
                Lesson = GSDE.Lessons.FirstOrDefault(x => x.Id == id);
                return LessonDTO.ConvertToDTO(Lesson);


            }
        }

        public static bool EditLesson(LessonDTO Lesson)
        {
            using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
            {

                var s = context.Lessons.FirstOrDefault(x => x.Id == Lesson.Id);
                if (s != null)
                {
                    s.Name = Lesson.Name?.TrimStart().TrimEnd();
                    s.Day = Lesson.Day?.TrimStart().TrimEnd();
                    s.StartHower = Lesson.StartHower?.TrimStart().TrimEnd();
                    s.FinishHower = Lesson.FinishHower?.TrimStart().TrimEnd();
                    s.MaxStudensNum = Lesson.MaxStudensNum;
                    s.LessonKind = Lesson.LessonKind?.TrimStart().TrimEnd();
                    s.TeacherId = Lesson.TeacherId;
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }


        }

        public static int AddLesson(LessonDTO LessonDTO)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {



                    Lesson Lesson = new Lesson();
                    Lesson.Name = LessonDTO.Name?.TrimStart().TrimEnd();
                    Lesson.Day = LessonDTO.Day?.TrimStart().TrimEnd();
                    Lesson.StartHower = LessonDTO.StartHower?.TrimStart().TrimEnd();
                    Lesson.FinishHower = LessonDTO.FinishHower?.TrimStart().TrimEnd();
                    Lesson.MaxStudensNum = LessonDTO.MaxStudensNum;
                    Lesson.LessonKind = LessonDTO.LessonKind?.TrimStart().TrimEnd();
                    Lesson.TeacherId = LessonDTO.TeacherId;

                    context.Lessons.Add(Lesson);
                    context.SaveChanges();
                    return context.Lessons.Max(o => o.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }



        public static List<LessonDTO> getLessonList()
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Lesson> LessonList = new List<Lesson>();
                LessonList = GSDE.Lessons.ToList();
                return LessonDTO.ConvertListToDTO(LessonList);
            }
        }

    }
}

