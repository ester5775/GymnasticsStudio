
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using DTO;

namespace Bll
{
    public class StudentFunction
    {
        public static List<StudentDTO> GetStudentsList()
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.ToList();
                return StudentDTO.Convert(studentList);


            }
        }

        public static List<StudentDTO> GetStudentsListByKind(string studentKind)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.Where(x => x.StudentKind == studentKind).ToList();
                return StudentDTO.Convert(studentList);


            }
        }



        public static List<StudentDTO> GetStudentsListByDetails(StudentDTO studentDTO)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.ToList();
                if (studentDTO.FirstName != "")
                    studentList = GetStudentsListByFirstName(studentList, studentDTO.FirstName);
                if (studentDTO.LastName != "")
                    studentList = GetStudentsListByLastName(studentList, studentDTO.LastName);
                if (studentDTO.PhoneNumber != "")
                    studentList = GetStudentsListByBuyPhoneNumber(studentList, studentDTO.PhoneNumber);
                if (studentDTO.IdentityNumber != "")
                    studentList = GetStudentsListByIdentityNumber(studentList, studentDTO.IdentityNumber);

                return StudentDTO.Convert(studentList);


            }
        }


        public static StudentDTO GetStudentDetailsByStudentId(int id)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                Student student = new Student();
                student = GSDE.Students.FirstOrDefault(x => x.Id == id);
                return StudentDTO.Convert(student);


            }
        }

        public static List<Student> GetStudentsListByFirstName(List<Student> students, string firstName)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.Where(x => x.FirstName == firstName).ToList();
                return studentList;


            }
        }

        public static List<Student> GetStudentsListByLastName(List<Student> students, string lastName)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.Where(x => x.LastName == lastName).ToList();
                return studentList;


            }
        }

        public static List<Student> GetStudentsListByBuyPhoneNumber(List<Student> students, string phoneNumber)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.Where(x => x.PhoneNumber == phoneNumber).ToList();
                return studentList;


            }
        }

        public static List<Student> GetStudentsListByIdentityNumber(List<Student> students, string identityNumber)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.Where(x => x.IdentityNumber == identityNumber).ToList();
                return studentList;


            }
        }


        public static int GetBalance(int id)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                int balance;
                int? balance1 = GSDE.Students.Where(x => x.Id == id).FirstOrDefault().Balance;
                if (balance1 == null)
                    balance = 0;
                else balance = (int)balance1;
                return balance;


            }
        }


        public static bool EditStudent(StudentDTO student)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {

                    var s = context.Students.FirstOrDefault(x => x.Id == student.Id);
                    if (s != null)
                    {
                        s.FirstName = student.FirstName;
                        s.LastName = student.LastName;
                        s.IdentityNumber = student.IdentityNumber;
                        s.PhoneNumber = student.PhoneNumber;
                        s.Pignicher = student.Pignicher;
                        s.StudentKind = student.StudentKind;
                        s.Balance = student.Balance;
                        context.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }



    }
}
