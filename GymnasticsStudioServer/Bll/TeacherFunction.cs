using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class TeacherFunction
    {
        
        public static List<string> GetTeacherNameList(List<int> teacherIdList)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<string> teacherNameList = new List<string>();
                foreach (int teacherId in teacherIdList)
                {
                    Teacher1 teacher = new Teacher1();
                    teacher = GSDE.Teacher1.Where(x => x.Id == teacherId).FirstOrDefault();
                    teacherNameList.Add(teacher.FirstName +" "+ teacher.LastName);
                }
                return teacherNameList;


            }
        }
            public static TeacherDTO GetTeacherDetailsByTeacherId(int id)
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                Teacher1 teacher = new Teacher1();
                teacher = GSDE.Teacher1.FirstOrDefault(x => x.Id == id);
                    return TeacherDTO.ConvertToDTO(teacher);


                }
            }

        public static bool EditTeacher(TeacherDTO teacher)
        {
            using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
            {

                var s = context.Teacher1.FirstOrDefault(x => x.Id == teacher.Id);
                if (s != null)
                {
                    s.FirstName = teacher.FirstName?.TrimStart().TrimEnd();
                    s.LastName = teacher.LastName?.TrimStart().TrimEnd();
                    s.IdentityNumber = teacher.IdentityNumber?.TrimStart().TrimEnd();
                    s.PhoneNumber = teacher.PhoneNumber?.TrimStart().TrimEnd();
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }


        }

        public static int AddTeacher(TeacherDTO teacherDTO)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {



                    Teacher1 teacher = new Teacher1();
                    teacher.FirstName = teacherDTO.FirstName?.TrimStart().TrimEnd();
                    teacher.LastName = teacherDTO.LastName?.TrimStart().TrimEnd();
                    teacher.IdentityNumber = teacherDTO.IdentityNumber?.TrimStart().TrimEnd();
                    teacher.PhoneNumber = teacherDTO.PhoneNumber?.TrimStart().TrimEnd();
                    context.Teacher1.Add(teacher);
                    context.SaveChanges();
                    return context.Teacher1.Max(o => o.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        

        public static List<TeacherDTO> getTeacherList()
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Teacher1> teacherList = new List<Teacher1>();
                teacherList = GSDE.Teacher1.ToList();
                return TeacherDTO.ConvertListToDTO(teacherList);
            }
        }

    }
}
