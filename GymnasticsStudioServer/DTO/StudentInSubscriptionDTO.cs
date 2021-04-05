using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class StudentInSubscriptionDTO
    {

        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> SubscribtionId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }


        public static StudentInSubscriptionDTO ConvertToDTO(StudentInSubscription studentInSubscription)
        {
            StudentInSubscriptionDTO studentInSubscriptionDTO = new StudentInSubscriptionDTO();
            studentInSubscriptionDTO.Id = studentInSubscription.Id;
            studentInSubscriptionDTO.StudentId = studentInSubscription.StudentId;
            studentInSubscriptionDTO.SubscribtionId = studentInSubscription.SubscribtionId;
            studentInSubscriptionDTO.StartDate = studentInSubscription.StartDate;
            studentInSubscriptionDTO.FinishDate = studentInSubscription.FinishDate;

            return studentInSubscriptionDTO;
        }

        public static List<StudentInSubscriptionDTO> ConvertListToDTO(List<StudentInSubscription> studentInSubscriptionList)
        {
            List<StudentInSubscriptionDTO> studentInSubscriptionDTOList = new List<StudentInSubscriptionDTO>();
            for (int i = 0; i < studentInSubscriptionDTOList.Count(); i++)
            {
                studentInSubscriptionDTOList.Add(ConvertToDTO(studentInSubscriptionList[i]));
            }
            return studentInSubscriptionDTOList;
        }

        public static StudentInSubscription ConvertFromDTO(StudentInSubscriptionDTO studentInSubscriptionDTO)
        {
            StudentInSubscription studentInSubscription = new StudentInSubscription();
            studentInSubscription.Id = studentInSubscriptionDTO.Id;
            studentInSubscription.StudentId = studentInSubscriptionDTO.StudentId;
            studentInSubscription.SubscribtionId = studentInSubscriptionDTO.SubscribtionId;
            studentInSubscription.StartDate = studentInSubscriptionDTO.StartDate;
            studentInSubscription.FinishDate = studentInSubscriptionDTO.FinishDate;


            return studentInSubscription;

            
        }

        public static List<StudentInSubscription> ConvertListFromDTO(List<StudentInSubscriptionDTO> studentInSubscriptionDTOsList)
        {
            List<StudentInSubscription> studentInSubscriptionList = new List<StudentInSubscription>();
            for (int i = 0; i < studentInSubscriptionDTOsList.Count(); i++)
            {
                studentInSubscriptionList.Add(ConvertFromDTO(studentInSubscriptionDTOsList[i]));
            }
            return studentInSubscriptionList;

        }

    }
}
