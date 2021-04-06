using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class StudentInLessonDTO
    {

        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> LessonId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }


        public static StudentInLessonDTO Convert(StudentInLesson studentInLesson)
        {
            StudentInLessonDTO studentInLessonDTO = new StudentInLessonDTO();
            studentInLessonDTO.Id = studentInLesson.Id;
            studentInLessonDTO.StudentId = studentInLesson.StudentId;
            studentInLessonDTO.LessonId = studentInLesson.LessonId;
            studentInLessonDTO.StartDate = studentInLesson.StartDate;
            studentInLessonDTO.FinishDate = studentInLesson.FinishDate;

            return studentInLessonDTO;
        }

        public static List<StudentInLessonDTO> Convert(List<StudentInLesson> studentInLessonList)
        {
            return studentInLessonList.Select(x => Convert(x)).ToList();

        }

        public static StudentInLesson Convert(StudentInLessonDTO studentInLessonDTO)
        {
            StudentInLesson studentInLesson = new StudentInLesson();
            studentInLesson.Id = studentInLessonDTO.Id;
            studentInLesson.StudentId = studentInLessonDTO.StudentId;
            studentInLesson.LessonId = studentInLessonDTO.LessonId;
            studentInLesson.StartDate = studentInLessonDTO.StartDate;
            studentInLesson.FinishDate = studentInLessonDTO.FinishDate;


            return studentInLesson;
        }

        public static List<StudentInLesson> Convert(List<StudentInLessonDTO> studentInLessonDTOsList)
        {
            return studentInLessonDTOsList.Select(x => Convert(x)).ToList();


        }
    }
}
