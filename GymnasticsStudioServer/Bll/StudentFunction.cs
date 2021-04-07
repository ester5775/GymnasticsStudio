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
                studentList = GSDE.Student;
                return StudentDTO.ConvertListToDTO(studentList);
               
            
            }
        }
    }
}
