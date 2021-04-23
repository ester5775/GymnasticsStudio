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
        
        public static List<LessonDTO> GetLessonsListBySubscriptionId(int subscriptionId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {

                List<Lesson> LessonList = new List<Lesson>();
                var lesson= GSDE.Subscriptions.Where(x => x.Id == subscriptionId).FirstOrDefault();
                if (lesson.LessonKind != default)
                {
                    int lessonKind = (int)lesson.LessonKind;                  
                    LessonList = GSDE.Lessons.Where(x => x.LessonKind == lessonKind).ToList();
                }
                return LessonDTO.ConvertListToDTO(LessonList);
            }
        }

    }
}
