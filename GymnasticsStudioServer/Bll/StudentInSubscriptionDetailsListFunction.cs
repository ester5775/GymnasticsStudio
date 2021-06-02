using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StudentInSubscriptionDetailsListFunction
    {
        public static List<StudentInSubscriptionDetailsListDTO> GetStudentInSubscriptionDetailsListListBystudentKind(string studentKind)
        {
            List<StudentDTO> studentDTOList = new List<StudentDTO>();
            studentDTOList = StudentFunction.GetStudentsListByKind(studentKind);
            List<StudentInSubscriptionDetailsListDTO> studentInSubscriptionDetailsListDTOList = new List<StudentInSubscriptionDetailsListDTO>();
            foreach (StudentDTO studentDTO in studentDTOList)
            {
                StudentInSubscriptionDetailsListDTO studentInSubscriptionDetailsListDTO = new StudentInSubscriptionDetailsListDTO();
                studentInSubscriptionDetailsListDTO.StudentName = studentDTO.FirstName + studentDTO.LastName;
                studentInSubscriptionDetailsListDTO.studentInSubscriptionDetailsDTOList = StudentInSubscripyionDetailsFunction.GetStudentInSubscripyionDetailsByStudentId(studentDTO.Id);

                studentInSubscriptionDetailsListDTOList.Add(studentInSubscriptionDetailsListDTO);
            }
            return studentInSubscriptionDetailsListDTOList;
        }
    }
}
