using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class TeacherDTO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }





        public static TeacherDTO Convert(Teacher1 teacher)
        {
            TeacherDTO teacherDTO = new TeacherDTO();
            teacherDTO.Id = teacher.Id;
            teacherDTO.LastName = teacher.LastName;
            teacherDTO.FirstName = teacher.FirstName;
            teacherDTO.IdentityNumber = teacher.IdentityNumber;
            teacherDTO.PhoneNumber = teacher.PhoneNumber;

            return teacherDTO;
        }

        public static List<TeacherDTO> Convert(List<Teacher1> teacherList)
        {
            return teacherList.Select(x => Convert(x)).ToList();

        }

        public static Teacher1 Convert(TeacherDTO teacherDTO)
        {
            Teacher1 teacher = new Teacher1();
            teacher.Id = teacherDTO.Id;
            teacher.LastName = teacherDTO.LastName;
            teacher.FirstName = teacherDTO.FirstName;
            teacher.IdentityNumber = teacherDTO.IdentityNumber;


            return teacher;
        }

        public static List<Teacher1> Convert(List<TeacherDTO> teacherDTOList)
        {
            return teacherDTOList.Select(x => Convert(x)).ToList();


        }

    }
}

