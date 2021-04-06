using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class LessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public string Day { get; set; }
        public string StartHower { get; set; }
        public string FinishHower { get; set; }
        public Nullable<int> MaxStudensNum { get; set; }
        public Nullable<int> MaxSerologersStudensNum { get; set; }



        public static LessonDTO Convert(Lesson lesson)
        {
            LessonDTO lessonDTO = new LessonDTO();
            lessonDTO.Id = lesson.Id;
            lessonDTO.Name = lesson.Name;
            lessonDTO.TeacherId = lesson.TeacherId;
            lessonDTO.Day = lesson.Day;
            lessonDTO.StartHower = lesson.StartHower;
            lessonDTO.FinishHower = lesson.FinishHower;
            lessonDTO.MaxStudensNum = lesson.MaxStudensNum;
            lessonDTO.MaxSerologersStudensNum = lesson.MaxSerologersStudensNum;

            return lessonDTO;
        }

        public static List<LessonDTO> Convert(List<Lesson> lessonList)
        {
            return lessonList.Select(x => Convert(x)).ToList();
        }

        public static Lesson Convert(LessonDTO lessonDTO)
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

        public static List<Lesson> Convert(List<LessonDTO> lessonDTOsList)
        {
            return lessonDTOsList.Select(x => Convert(x)).ToList();

        }
    }
}

    