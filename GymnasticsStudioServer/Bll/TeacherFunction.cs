using Dal;
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
    }
}
