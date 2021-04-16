

using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TeacherDTO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }


        public static TeacherDTO ConvertToDTO(Teacher1 teacher)
        {
            TeacherDTO teacherDTO = new TeacherDTO();
            teacherDTO.Id = teacher.Id;
            teacherDTO.LastName = teacher.LastName;
            teacherDTO.FirstName = teacher.FirstName;
            teacherDTO.IdentityNumber = teacher.IdentityNumber;
            teacherDTO.PhoneNumber = teacher.PhoneNumber;
            
            return teacherDTO;
        }

        public static List<TeacherDTO> ConvertListToDTO(List<Teacher1> teacherList)
        {
            List<TeacherDTO> teacherDTOList = new List<TeacherDTO>();
            for (int i = 0; i < teacherList.Count(); i++)
            {
                teacherDTOList.Add(ConvertToDTO(teacherList[i]));
            }
            return teacherDTOList;
        }

        public static Teacher1 ConvertFromDTO(TeacherDTO teacherDTO)
        {
            Teacher1 teacher = new Teacher1();
            teacher.Id = teacherDTO.Id;
            teacher.LastName = teacherDTO.LastName;
            teacher.FirstName = teacherDTO.FirstName;
            teacher.IdentityNumber = teacherDTO.IdentityNumber;
           

            return teacher;
        }

        public static List<Teacher1> ConvertListFromDTO(List<TeacherDTO> teacherDTOList)
        {
            List<Teacher1> teacherList = new List<Teacher1>();
            for (int i = 0; i < teacherDTOList.Count(); i++)
            {
                teacherList.Add(ConvertFromDTO(teacherDTOList[i]));
            }
            return teacherList;

        }

    }
}
