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
            using (Dal.Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Student> studentList = new List<Student>();
                studentList = GSDE.Students.ToList();
                return StudentDTO.Convert(studentList);


            }
        }
        public static StudentDTO GetStudentById(int id)
        {
            using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
            {
                return StudentDTO.Convert(context.Students.FirstOrDefault(x => x.Id == id));
            }
        }

        public static bool EditStudent(StudentDTO student)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {

                    var s = context.Students.FirstOrDefault(x => x.Id == student.Id);
                    s.FirstName = student.FirstName;
                    s.LastName = student.LastName;
                    s.IdentityNumber = student.IdentityNumber;
                    s.PhoneNumber = student.PhoneNumber;
                    s.Pignicher = student.Pignicher;
                    s.StudentKind = student.StudentKind;
                    s.Balance = student.Balance;
                    s.CreditDetailsId = student.CreditDetailsId;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return false;
        }
    }
}
