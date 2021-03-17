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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Pignicher { get; set; }
        public string StudentKind { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<int> CreditDetailsId { get; set; }


       
        public static StudentDTO ConvertToDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Id = student.Id;           
            studentDTO.FirstName = student.FirstName;
            studentDTO.LastName = student.LastName;
            studentDTO.IdentityNumber = student.IdentityNumber;
            studentDTO.PhoneNumber = student.PhoneNumber;
            studentDTO.Pignicher = student.Pignicher;
            studentDTO.StudentKind = student.StudentKind;
            studentDTO.Balance = student.Balance;
            studentDTO.CreditDetailsId = student.CreditDetailsId;
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
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.IdentityNumber = studentDTO.IdentityNumber;
            student.PhoneNumber = studentDTO.PhoneNumber;
            student.Pignicher = studentDTO.Pignicher;
            student.StudentKind = studentDTO.StudentKind;
            student.Balance = studentDTO.Balance;
            student.CreditDetailsId = studentDTO.CreditDetailsId;

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
