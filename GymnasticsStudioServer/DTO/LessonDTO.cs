using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public string Day { get; set; }
        public string StartHower { get; set; }
        public string FinishHower { get; set; }
        public Nullable<int> MaxStudensNum { get; set; }
        public Nullable<int> MaxSerologersStudensNum { get; set; }

        public static LessonDTO ConvertToDTO(Lesson lesson)
        {
            LessonDTO lessonDTO = new LessonDTO();
            lessonDTO.Id = lesson.Id;
            lessonDTO.Name = lesson.Name;
            lessonDTO.TeacherId = lesson.TeacherId;
            lessonDTO.Day = lesson.Day;
            lessonDTO.StartHower= lesson.StartHower;
            lessonDTO.FinishHower = lesson.FinishHower;
            lessonDTO.MaxStudensNum = lesson.MaxStudensNum;
            lessonDTO.MaxSerologersStudensNum = lesson.MaxSerologersStudensNum;
           
            return lessonDTO;
        }

        public static List<LessonDTO> ConvertListToDTO(List<Lesson> lessonList)
        {
            List<LessonDTO> lessonDTOsList = new List<LessonDTO>();
            for (int i = 0; i < lessonList.Count(); i++)
            {
                lessonDTOsList.Add(ConvertToDTO(lessonList[i]));
            }
            return lessonDTOsList;
        }

        public static Lesson ConvertFromDTO(LessonDTO lessonDTO)
        {
           
            Lesson lesson = new Lesson();
            lesson.Id = lessonDTO.Id;
            lesson.Name = lessonDTO.Name;
            lesson.TeacherId = lessonDTO.TeacherId;
            lesson.Day = lessonDTO.Day;
            lesson.StartHower = lessonDTO.StartHower;
            lesson.FinishHower = lessonDTO.FinishHower;
            lesson.MaxStudensNum = lessonDTO.MaxStudensNum;
            lesson.MaxSerologersStudensNum = lessonDTO.MaxSerologersStudensNum;

            return lesson;

            
        }

        public static List<Lesson> ConvertListFromDTO(List<LessonDTO> lessonDTOsList)
        {
            List<Lesson> lessonList = new List<Lesson>();
            for (int i = 0; i < lessonDTOsList.Count(); i++)
            {
                lessonList.Add(ConvertFromDTO(lessonDTOsList[i]));
            }
            return lessonList;

        }
    }
}
