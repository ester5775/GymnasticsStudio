
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                List<Student> studentList = GSDE.Students.Where(x =>
                (string.IsNullOrEmpty(studentDTO.FirstName) || x.FirstName == studentDTO.FirstName)
                && (string.IsNullOrEmpty(studentDTO.LastName) || x.LastName == studentDTO.LastName)
                && (string.IsNullOrEmpty(studentDTO.PhoneNumber) || x.PhoneNumber == studentDTO.PhoneNumber)
                && (string.IsNullOrEmpty(studentDTO.IdentityNumber) || x.PhoneNumber == studentDTO.IdentityNumber)).ToList();
                //if (studentDTO.FirstName != "")
                //    studentList = GetStudentsListByFirstName(studentList, studentDTO.FirstName);
                //if (studentDTO.LastName != "")
                //    studentList = GetStudentsListByLastName(studentList, studentDTO.LastName);
                //if (studentDTO.PhoneNumber != "")
                //    studentList = GetStudentsListByBuyPhoneNumber(studentList, studentDTO.PhoneNumber);
                //if (studentDTO.IdentityNumber != "")
                //    studentList = GetStudentsListByIdentityNumber(studentList, studentDTO.IdentityNumber);

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
                studentList = GSDE.Students.Where(x => x.LastName == lastName).Include(x => x.CreditDetail).ToList();
                return studentList;


            }
        }

        public static List<Student> GetStudentsListByBuyPhoneNumber(List<Student> students, string phoneNumber)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.Where(x => x.PhoneNumber == phoneNumber).Include(x => x.CreditDetail).ToList();
                return studentList;


            }
        }

        public static List<Student> GetStudentsListByIdentityNumber(List<Student> students, string identityNumber)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.Where(x => x.IdentityNumber == identityNumber).Include(x => x.CreditDetail).ToList();
                return studentList;


            }
        }


        public static int GetBalance(int id)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                int balance;
                double? balance1 = GSDE.Students.Where(x => x.Id == id).FirstOrDefault().Balance;
                if (balance1 == null)
                    balance = 0;
                else balance = (int)balance1;
                return balance;


            }
        }


        public static bool EditStudent(StudentDTO student)
        {
            using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
            {

                var s = context.Students.FirstOrDefault(x => x.Id == student.Id);
                if (s != null)
                {
                    s.FirstName = student.FirstName?.TrimStart().TrimEnd();
                    s.LastName = student.LastName?.TrimStart().TrimEnd();
                    s.IdentityNumber = student.IdentityNumber?.TrimStart().TrimEnd();
                    s.PhoneNumber = student.PhoneNumber?.TrimStart().TrimEnd();
                    s.Pignicher = student.Pignicher?.TrimStart().TrimEnd();
                    s.Comments = student.Comments?.TrimStart().TrimEnd();
                    if (s.CreditDetail == null)
                    {
                        CreditDetail creditDetail = new CreditDetail();
                        creditDetail.Students.Add(s);
                    }
                    s.CreditDetail.CreditNumber = student.CreditCardNumber;
                    s.HMO = student.HMO?.TrimStart().TrimEnd();
                    s.Addrees = student.Addrees?.TrimStart().TrimEnd();
                    s.BirthDay = student?.BirthDay;
                    s.StartDate = student?.StartDate.TrimStart().TrimEnd();
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }


        }

        public static int AddStudent(StudentDTO studentDTO)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {



                    Student student = new Student();
                    student.FirstName = studentDTO.FirstName?.TrimStart().TrimEnd();
                    student.LastName = studentDTO.LastName?.TrimStart().TrimEnd();
                    student.IdentityNumber = studentDTO.IdentityNumber?.TrimStart().TrimEnd();
                    student.PhoneNumber = studentDTO.PhoneNumber?.TrimStart().TrimEnd();
                    student.Pignicher = studentDTO.Pignicher?.TrimStart().TrimEnd();
                    student.Comments = studentDTO.Comments?.TrimStart().TrimEnd();
                    //
                    student.HMO = studentDTO.HMO?.TrimStart().TrimEnd();
                    student.Addrees = studentDTO.Addrees?.TrimStart().TrimEnd();
                    student.BirthDay = studentDTO?.BirthDay;
                    //
                    student.StudentKind = studentDTO?.StudentKind;
                    context.Students.Add(student);
                    context.SaveChanges();

                    return context.Students.Max(o => o.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }



    }
}
