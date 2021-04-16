
﻿using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentInLessonDTO
    {

        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> LessonId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }


        public static StudentInLessonDTO ConvertToDTO(StudentInLesson studentInLesson)
        {
            StudentInLessonDTO studentInLessonDTO = new StudentInLessonDTO();
            studentInLessonDTO.Id = studentInLesson.Id;
            studentInLessonDTO.StudentId = studentInLesson.StudentId;
            studentInLessonDTO.LessonId = studentInLesson.LessonId;
            studentInLessonDTO.StartDate = studentInLesson.StartDate;
            studentInLessonDTO.FinishDate = studentInLesson.FinishDate;
           
            return studentInLessonDTO;
        }

        public static List<StudentInLessonDTO> ConvertListToDTO(List<StudentInLesson> studentInLessonList)
        {
            List<StudentInLessonDTO> studentInLessonDTOsList = new List<StudentInLessonDTO>();
            for (int i = 0; i < studentInLessonList.Count(); i++)
            {
                studentInLessonDTOsList.Add(ConvertToDTO(studentInLessonList[i]));
            }
            return studentInLessonDTOsList;
        }

        public static StudentInLesson ConvertFromDTO(StudentInLessonDTO studentInLessonDTO)
        {
            StudentInLesson studentInLesson = new StudentInLesson();
            studentInLesson.Id = studentInLessonDTO.Id;
            studentInLesson.StudentId = studentInLessonDTO.StudentId;
            studentInLesson.LessonId = studentInLessonDTO.LessonId;
            studentInLesson.StartDate = studentInLessonDTO.StartDate;
            studentInLesson.FinishDate = studentInLessonDTO.FinishDate;
           

            return studentInLesson;
        }

        public static List<StudentInLesson> ConvertListFromDTO(List<StudentInLessonDTO> studentInLessonDTOsList)
        {
            List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
            for (int i = 0; i < studentInLessonDTOsList.Count(); i++)
            {
                studentInLessonList.Add(ConvertFromDTO(studentInLessonDTOsList[i]));
            }
            return studentInLessonList;

        }
    }
}
