using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;


namespace DTO
{
    public class StudentDTO
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string IdentityNumber;
        public string PhoneNumber;
        public string MobilePhoneNumber;
        public int Balance;

        public static StudentDTO ConvertToDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Id = student.Id;
            studentDTO.LastName = student.LastName;
            studentDTO.FirstName = student.FirstName;
            studentDTO.IdentityNumber = student.IdentityNumber;
            studentDTO.PhoneNumber = student.PhoneNumber;
            studentDTO.MobilePhoneNumber = student.MobilePhoneNumber;
            studentDTO.Balance = student.Balance;
            return studentDTO;
        }

        public static List<StudentDTO> ConvertListToDTO(List<Student> studentsList)
        {
            List<StudentDTO> studentDTOsList = new List<StudentDTO>();
            for (int i = 0; i < studentsList.Count(); i++)
            {
                studentDTOsList.Add(ConvertToDTO(studentsList[i]));
            }
            return studentDTOsList;
        }

        public static Student ConvertFromDTO(StudentDTO studentDTO)
        {
            Student student = new Student();
            student.Id = studentDTO.Id;
            student.LastName = studentDTO.LastName;
            student.FirstName = studentDTO.FirstName;
            student.IdentityNumber = studentDTO.IdentityNumber;
            student.PhoneNumber = studentDTO.PhoneNumber;
            student.MobilePhoneNumber = studentDTO.MobilePhoneNumber;
            student.Balance = studentDTO.Balance;
            return student;
        }

        public static List<Student> ConvertListFromDTO(List<StudentDTO> studentDTOsList)
        {
            List<Student> studentsList = new List<Student>();
            for (int i = 0; i < studentDTOsList.Count(); i++)
            {
                studentsList.Add(ConvertFromDTO(studentDTOsList[i]));
            }
            return studentsList;

        }

    }
}
