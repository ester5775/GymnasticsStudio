using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentInSubscriptionDetailsDTO
    {
        public int WeehId { get; set; }
        public string WeeklyPortion { get; set; }
        public string WeekStartDate { get; set; }
        public string WeekFinishDate { get; set; }
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonDay { get; set; }
        public string LessonStartHower { get; set; }
        public string LessonFinishHower { get; set; }
        public int StudentInLessonId { get; set; }
        public Nullable<bool> Attendance { get; set; }
        public int SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public int PaymentId { get; set; }
        public string PaymentStartDate { get; set; }
        public string PaymentFinishDate { get; set; }
        public Nullable<int> PaymentSum { get; set; }
        public int StudntId { get; set; }
        public Nullable<int> Balance { get; set; }
    }
}
