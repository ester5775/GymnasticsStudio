using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StudentInLessonFunction
    {

        public static int ConvertHebrewDayNameToNumber(string DayName)
        {
            switch( DayName)
            {
                case "ראשון":
                    return 1;
                case "שני":
                    return 2;
                case "שלישי":
                    return 3;
                case "רביעי":
                    return 4;
                case "חמישי":
                    return 5;
                case "שישי":
                    return 6;
                case "שבת":
                    return 7;
            }
            return 0;
        }

        public static bool PostStudentInLessons(LessonDTO lessonDTO,int studentId,string date)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {

                    DateTime Date = Convert.ToDateTime(date);
                    StudentInSubscription studentInSubscription = new StudentInSubscription();
                    studentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= Date && x.FinishDate >= Date).FirstOrDefault();
                    List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
                    studentInLessonList = GSDE.StudentInLessons.Where(x => x.StudentInSubscriptionId == studentInSubscription.Id).ToList();
                    StudentInLesson studentInLesson = studentInLessonList[0];
                    var lastLessonDay= GSDE.Lessons.Where(x => x.Id == studentInLesson.LessonId).FirstOrDefault().Day;
                    double reminder=ConvertHebrewDayNameToNumber(lessonDTO.Day);
                    reminder -= ConvertHebrewDayNameToNumber(lastLessonDay);
                    
                    for (int i = 0; i < studentInLessonList.Count(); i++)
                    {
                        var s=studentInLessonList[i];
                        s.Date=Convert.ToDateTime(s.Date).AddDays(reminder);
                        
                        GSDE.SaveChanges();
                    }
                       
                        return true;
                    
           
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static List<LessonInDateDTO> GetAbsencesListByStudentId( int studentId)
        {
            List<LessonInDateDTO> lessonInDateDTOList = new List<LessonInDateDTO>();
            List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                studentInLessonList = GSDE.StudentInLessons.Where(x => x.StudentId == studentId && x.Attendance==false).ToList();
           
                for(int i=0;i<studentInLessonList.Count();i++)
                {
                    LessonInDateDTO lessonInDateDTO = new LessonInDateDTO();                    
                    lessonInDateDTO.Date = studentInLessonList[i].Date.ToString();
                    var studentInLessonId=studentInLessonList[i].LessonId;
                    lessonInDateDTO.LessonName = GSDE.Lessons.Where(x => x.Id == studentInLessonId).First().Name;
                    lessonInDateDTOList.Add(lessonInDateDTO);
                }
            }
            return lessonInDateDTOList;
        }
    }
}
