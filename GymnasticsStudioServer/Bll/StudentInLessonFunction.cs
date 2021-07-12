using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StudentInLessonFunction
    {

        public static int ConvertHebrewDayNameToNumber(string DayName)
        {
            switch( DayName)
            {
                case "ראשון":
                    return 0;
                case "שני":
                    return 1;
                case "שלישי":
                    return 2;
                case "רביעי":
                    return 3;
                case "חמישי":
                    return 4;
                case "שישי":
                    return 5;
                case "שבת":
                    return 6;
            }
            return 0;
        }

        public static bool PostStudentInLessons(LessonDTO lessonDTO,int studentId,string date)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {

                    DateTime Date = Convert.ToDateTime(date);
                    StudentInSubscription studentInSubscription = new StudentInSubscription();
                    studentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= Date && x.FinishDate >= Date).FirstOrDefault();
                    List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
                    studentInLessonList = GSDE.StudentInLessons.Where(x => x.StudentInSubscriptionId == studentInSubscription.Id).ToList();
                    StudentInLesson studentInLesson1 = studentInLessonList[0];
                    var lastLessonDay= GSDE.Lessons.Where(x => x.Id == studentInLesson1.LessonId).FirstOrDefault().Day;
                    double reminder=ConvertHebrewDayNameToNumber(lessonDTO.Day);
                    reminder -= ConvertHebrewDayNameToNumber(lastLessonDay);
                    if (Convert.ToDateTime(studentInLesson1.Date).AddDays(reminder) < studentInSubscription.StartDate)
                        reminder += 7;

                    for (int i = 0; i < studentInLessonList.Count(); i++)
                    {
                        var studentInLesson = studentInLessonList[i];
                        if (studentInLesson.Date >= Date && Convert.ToDateTime(studentInLesson.Date).AddDays(reminder) >= Date)
                        {
                            
                            studentInLesson.Date = Convert.ToDateTime(studentInLesson.Date).AddDays(reminder);
                            studentInLesson.LessonId = lessonDTO.Id;

                            //Week week = new Week();
                            //DateTime Date2 = Date.AddDays(7);
                            //week = GSDE.Weeks.Where(x => x.Date <= Date && x.Date > Date2).FirstOrDefault();
                            //if (week == default) return false;
                            //studentInLesson.WeekId = week.Id;

                            GSDE.SaveChanges();
                        }
                    }
                       
                        return true;
                    
           
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static List<LessonInDateDTO> GetAbsencesListByStudentId( int studentId)
        {
            List<LessonInDateDTO> lessonInDateDTOList = new List<LessonInDateDTO>();
            List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                studentInLessonList = GSDE.StudentInLessons.Where(x => x.StudentId == studentId && x.Attendance==false).ToList();
           
                for(int i=0;i<studentInLessonList.Count();i++)
                {
                    LessonInDateDTO lessonInDateDTO = new LessonInDateDTO();                    
                    lessonInDateDTO.Date = studentInLessonList[i].Date.ToString();
                    var studentInLessonId=studentInLessonList[i].LessonId;
                    lessonInDateDTO.LessonName = GSDE.Lessons.Where(x => x.Id == studentInLessonId).First().Name;
                    lessonInDateDTOList.Add(lessonInDateDTO);
                }
            }
            return lessonInDateDTOList;
        }

        public static bool UpdateAttendence(int studentInLessonId, bool attendance)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    StudentInLesson studentInLesson = new StudentInLesson();
                    studentInLesson = GSDE.StudentInLessons.Where(x => x.Id == studentInLessonId).FirstOrDefault();
                    if (studentInLesson == default) return false;
                    studentInLesson.Attendance = attendance;
                    GSDE.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        //תשלום לשיעור
        public static ExceptionsEnum paymentOfLessson(StudentInLesson studentInLesson, Subscription subscription,int studentId)
    {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    
                    int lessonPayment = (int)(subscription.Price / (subscription.WeeksNum * subscription.DaysInWeekNum));
                    
                    Student student = GSDE.Students.Where(x => x.Id == studentId).FirstOrDefault();
                    if (student == default) return ExceptionsEnum.StudentUndefine;
                    student.Balance -= lessonPayment;
                    GSDE.SaveChanges();
                    while (lessonPayment > 0)
                    {
                        Payment payment = GSDE.Payments.Where(x => x.StudentId == studentId && x.FinishDate == null).ToList().OrderBy(o => o.StartDate).FirstOrDefault();
                        switch (payment)
                        {
                            case null:
                                payment = new Payment();
                                payment.StartDate = DateTime.Now;
                                payment.StudentId = studentId;
                                payment.Sum = 0 - lessonPayment;
                                payment.FormOfPayment = "חוב";
                                payment.Balance = 0 - lessonPayment;
                                GSDE.Payments.Add(payment);
                                GSDE.SaveChanges();
                                payment = GSDE.Payments.Where(x => x.StudentId == studentId && x.FinishDate == default).FirstOrDefault();
                                studentInLesson.PaymentId = payment.Id;
                                break;
                            default:
                                if (payment.Balance > 0 && payment.Balance < lessonPayment)
                                {
                                    lessonPayment = (int)(lessonPayment - payment.Balance);
                                    payment.Balance = 0;
                                    payment.FinishDate = DateTime.Now;
                                    GSDE.SaveChanges();
                                }
                                else
                                {
                                    payment.Balance = payment.Balance - lessonPayment;
                                    lessonPayment = 0;
                                    GSDE.SaveChanges();
                                    studentInLesson.PaymentId = payment.Id;
                                    GSDE.SaveChanges();
                                }
                                break;
                        }

                        GSDE.StudentInLessons.Add(studentInLesson);
                        GSDE.SaveChanges();


                    }
                }
                return ExceptionsEnum.True;                           
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
 

        public static ExceptionsEnum CreateLessonListBySubscriptionIdLessonIdStudentInSubscriptionId(int StudentId, int LessonId, DateTime FromDate,int SubscreptionId,int StudentInSubscreptionId)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    Lesson lesson = new Lesson();
                    lesson = GSDE.Lessons.Where(x => x.Id == LessonId).FirstOrDefault();
                    if (lesson == default) return ExceptionsEnum.LessonUndefine;
                    if (FromDate == default) return ExceptionsEnum.FromDateUndefine;
                    DateTime SundayDate = FromDate.AddDays(0 - (int)FromDate.DayOfWeek);
                    int d = ConvertHebrewDayNameToNumber(lesson.Day) - (int)SundayDate.DayOfWeek;
                    DateTime Date = SundayDate.AddDays(d);
                    if (Date < FromDate)
                        Date = Date.AddDays(7);
                    Subscription subscription = new Subscription();
                    subscription = GSDE.Subscriptions.Where(x => x.Id == SubscreptionId).FirstOrDefault();
                    if (subscription == default) return ExceptionsEnum.SubscriptionUndefine;
                    for (int i = 0; i < subscription.WeeksNum; i++, Date = Date.AddDays(7))
                    {
                        StudentInLesson studentInLesson = new StudentInLesson();
                        studentInLesson.Attendance = true;
                        studentInLesson.Date = Date;
                        studentInLesson.LessonId = LessonId;
                        studentInLesson.StudentId = StudentId;
                        studentInLesson.StudentInSubscriptionId = StudentInSubscreptionId;
                        Week week = new Week();
                        DateTime Date2 = Date.AddDays(-7);
                        week = GSDE.Weeks.Where(x => x.Date <= Date && x.Date > Date2).FirstOrDefault();
                        if (week == default) return ExceptionsEnum.WeekUndefine;
                        studentInLesson.WeekId = week.Id;



                        //טיפול בתשלום השיעור
                        // var l=paymentOfLessson(studentInLesson, subscription, StudentId);
                        int lessonPayment = (int)(subscription.Price / (subscription.WeeksNum * subscription.DaysInWeekNum));

                        Student student = GSDE.Students.Where(x => x.Id == StudentId).FirstOrDefault();
                        if (student == default) return ExceptionsEnum.StudentUndefine;
                        student.Balance -= lessonPayment;
                        GSDE.SaveChanges();
                        while (lessonPayment > 0)
                        {
                            Payment payment = GSDE.Payments.Where(x => x.StudentId == StudentId && x.FinishDate == null).ToList().OrderBy(o => o.StartDate).FirstOrDefault();
                            switch (payment)
                            {
                                case null:
                                    payment = new Payment();
                                    payment.StartDate = DateTime.Now;
                                    payment.StudentId = StudentId;
                                    payment.Sum = 0 - lessonPayment;
                                    payment.FormOfPayment = "חוב";
                                    payment.Balance = 0 - lessonPayment;
                                    GSDE.Payments.Add(payment);
                                    GSDE.SaveChanges();
                                    payment = GSDE.Payments.Where(x => x.StudentId == StudentId && x.FinishDate == default).FirstOrDefault();
                                    studentInLesson.PaymentId = payment.Id;
                                    break;
                                default:
                                    if (payment.Balance > 0 && payment.Balance < lessonPayment)
                                    {
                                        lessonPayment = (int)(lessonPayment - payment.Balance);
                                        payment.Balance = 0;
                                        payment.FinishDate = DateTime.Now;
                                        GSDE.SaveChanges();
                                    }
                                    else
                                    {
                                        payment.Balance = payment.Balance - lessonPayment;
                                        lessonPayment = 0;
                                        GSDE.SaveChanges();
                                        studentInLesson.PaymentId = payment.Id;
                                        GSDE.SaveChanges();
                                    }
                                    break;
                            }

                            GSDE.StudentInLessons.Add(studentInLesson);
                            GSDE.SaveChanges();

                            // if (l != ExceptionsEnum.True)
                            // return l;
                        }
                        
                    }
                    return ExceptionsEnum.True;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public static ExceptionsEnum CreateLessonList(int StudentId, int LessonId,int StudentInSubscreptionId)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {

                    // בדיקה אם לתלמידה מספר שיעורים באותו שבוע נמוך ממספר השיעורים שאמור להיות במנוי
                    StudentInSubscription studentInSubscription = new StudentInSubscription();
                    studentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.Id == StudentInSubscreptionId).FirstOrDefault();
                    if (studentInSubscription == default) return ExceptionsEnum.StudetInSubscriptionUndefine;
                    Subscription subscription = new Subscription();
                    subscription = GSDE.Subscriptions.Where(x => x.Id == studentInSubscription.SubscribtionId).FirstOrDefault();
                    if (subscription == default) return ExceptionsEnum.SubscriptionUndefine;
                    List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
                    studentInLessonList = GSDE.StudentInLessons.Where(x => x.StudentInSubscriptionId == StudentInSubscreptionId).ToList();
                    studentInLessonList = studentInLessonList.Where(x => x.Date >= studentInLessonList[0].Date && x.Date < ((DateTime)studentInLessonList[0].Date).AddDays(7)).ToList();
                    //אם לא החזרת שגיאה מתאימה אחרי יצירת enum
                    if (studentInLessonList.Count >= subscription.DaysInWeekNum) return ExceptionsEnum.LessonsNumException;

                    //אם כן לולאה כמס השבועות במנוי ליצירת שיעור כולל טיפול בתשלום וביצירת שבועות 
                    WeekFunction.AddWeeksUpTo((DateTime)studentInSubscription.FinishDate);

                    Lesson lesson = new Lesson();
                    lesson = GSDE.Lessons.Where(x => x.Id == LessonId).FirstOrDefault();
                    if (lesson == default) return ExceptionsEnum.LessonUndefine;
                    if (studentInSubscription.StartDate == default) return ExceptionsEnum.StartDateOfStudentInSubscriptionUndefine;
                    DateTime SundayDate = ((DateTime)studentInSubscription.StartDate).AddDays(0 - (int)((DateTime)studentInSubscription.StartDate).DayOfWeek);
                    int d = ConvertHebrewDayNameToNumber(lesson.Day) - (int)SundayDate.DayOfWeek;
                    DateTime Date = SundayDate.AddDays(d);
                    if (Date < studentInSubscription.StartDate)
                        Date = Date.AddDays(7);
                    for (int i = 0; i < subscription.WeeksNum; i++, Date = Date.AddDays(7))
                    {
                        StudentInLesson studentInLesson = new StudentInLesson();
                        studentInLesson.Attendance = true;
                        studentInLesson.Date = Date;
                        studentInLesson.LessonId = LessonId;
                        studentInLesson.StudentId = StudentId;
                        studentInLesson.StudentInSubscriptionId = StudentInSubscreptionId;
                        Week week = new Week();
                        DateTime Date2 = Date.AddDays(-7);

                        week = GSDE.Weeks.Where(y=>y.Date <= Date && y.Date > Date2).FirstOrDefault();
                        if (week == default) return ExceptionsEnum.WeekUndefine;
                        studentInLesson.WeekId = week.Id;

                        // var x=paymentOfLessson(studentInLesson, subscription, StudentId);
                        // if (x != ExceptionsEnum.True)
                        //   return x;
                        int lessonPayment = (int)(subscription.Price / (subscription.WeeksNum * subscription.DaysInWeekNum));

                        Student student = GSDE.Students.Where(x => x.Id == StudentId).FirstOrDefault();
                        if (student == default) return ExceptionsEnum.StudentUndefine;
                        student.Balance -= lessonPayment;
                        GSDE.SaveChanges();
                        while (lessonPayment > 0)
                        {
                            Payment payment = GSDE.Payments.Where(x => x.StudentId == StudentId && x.FinishDate == null).ToList().OrderBy(o => o.StartDate).FirstOrDefault();
                            switch (payment)
                            {
                                case null:
                                    payment = new Payment();
                                    payment.StartDate = DateTime.Now;
                                    payment.StudentId = StudentId;
                                    payment.Sum = 0 - lessonPayment;
                                    payment.FormOfPayment = "חוב";
                                    payment.Balance = 0 - lessonPayment;
                                    GSDE.Payments.Add(payment);
                                    GSDE.SaveChanges();
                                    payment = GSDE.Payments.Where(x => x.StudentId == StudentId && x.FinishDate == default).FirstOrDefault();
                                    studentInLesson.PaymentId = payment.Id;
                                    break;
                                default:
                                    if (payment.Balance > 0 && payment.Balance < lessonPayment)
                                    {
                                        lessonPayment = (int)(lessonPayment - payment.Balance);
                                        payment.Balance = 0;
                                        payment.FinishDate = DateTime.Now;
                                        GSDE.SaveChanges();
                                    }
                                    else
                                    {
                                        payment.Balance = payment.Balance - lessonPayment;
                                        lessonPayment = 0;
                                        GSDE.SaveChanges();
                                        studentInLesson.PaymentId = payment.Id;
                                        GSDE.SaveChanges();
                                    }
                                    break;
                            }
                        }

                            GSDE.StudentInLessons.Add(studentInLesson);
                        GSDE.SaveChanges();
                    }   
                }            

            return ExceptionsEnum.True;
            }            
            catch (Exception e)
            {
                throw (e);
            }
        }

        
        public static ExceptionsEnum CreateLessonListByDate(int StudentId, int LessonId, String Date)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    DateTime date = Convert.ToDateTime(Date);
                    StudentInSubscription studentInSubscription = new StudentInSubscription();
                    studentInSubscription=GSDE.StudentInSubscriptions.Where(x => x.StudentId == StudentId && x.StartDate <= date && x.FinishDate > date).FirstOrDefault();
                    if (studentInSubscription == default) return ExceptionsEnum.StudentInSubscriptionUndefine;
                    return CreateLessonList(StudentId, LessonId, studentInSubscription.Id);
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }

    }

