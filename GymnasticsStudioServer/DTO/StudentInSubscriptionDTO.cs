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


        public static StudentInSubscriptionDTO Convert(StudentInSubscription studentInSubscription)
        {
            StudentInSubscriptionDTO studentInSubscriptionDTO = new StudentInSubscriptionDTO();
            studentInSubscriptionDTO.Id = studentInSubscription.Id;
            studentInSubscriptionDTO.StudentId = studentInSubscription.StudentId;
            studentInSubscriptionDTO.SubscribtionId = studentInSubscription.SubscribtionId;
            studentInSubscriptionDTO.StartDate = studentInSubscription.StartDate;
            studentInSubscriptionDTO.FinishDate = studentInSubscription.FinishDate;

            return studentInSubscriptionDTO;
        }

        public static List<StudentInSubscriptionDTO> Convert(List<StudentInSubscription> studentInSubscriptionList)
        {
            return studentInSubscriptionList.Select(x => Convert(x)).ToList();

        }

        public static StudentInSubscription Convert(StudentInSubscriptionDTO studentInSubscriptionDTO)
        {
            StudentInSubscription studentInSubscription = new StudentInSubscription();
            studentInSubscription.Id = studentInSubscriptionDTO.Id;
            studentInSubscription.StudentId = studentInSubscriptionDTO.StudentId;
            studentInSubscription.SubscribtionId = studentInSubscriptionDTO.SubscribtionId;
            studentInSubscription.StartDate = studentInSubscriptionDTO.StartDate;
            studentInSubscription.FinishDate = studentInSubscriptionDTO.FinishDate;


            return studentInSubscription;


        }

        public static List<StudentInSubscription> Convert(List<StudentInSubscriptionDTO> studentInSubscriptionDTOsList)
        {
            return studentInSubscriptionDTOsList.Select(x => Convert(x)).ToList();


        }

    }
}

