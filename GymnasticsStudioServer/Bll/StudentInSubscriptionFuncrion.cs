
using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StudentInSubscriptionFuncrion
    {

        public static List<StudentInSubscriptionDTO> GetStudentInSubscriptionListByStudentId(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<List<StudentInSubscriptionDTO>> studentInSubscriptionListsList = new List<List<StudentInSubscriptionDTO>>();
                List<StudentInSubscription> studentInSubscriptionList = new List<StudentInSubscription>();
                List<Payment> paymentList = PaymentDTO.ConvertListFromDTO(PaymentFunction.GetStudentPaymentsList(studentId));
                foreach (Payment payment in paymentList)
                {
                    studentInSubscriptionList = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate < payment.StartDate).ToList();
                    studentInSubscriptionListsList.Add(StudentInSubscriptionDTO.ConvertListToDTO(studentInSubscriptionList));
                }
                return StudentInSubscriptionDTO.ConvertListToDTO(studentInSubscriptionList);
            }


        }
        public static List<List<string>> GetStudentInSubscriptionNamesListByStudentId(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<List<StudentInSubscriptionDTO>> studentInSubscriptionListsList = new List<List<StudentInSubscriptionDTO>>();
                List<StudentInSubscription> studentInSubscriptionList = new List<StudentInSubscription>();
                List<List<string>> subscriptionNameList = new List<List<string>>();
                List<Payment> paymentList = PaymentDTO.ConvertListFromDTO(PaymentFunction.GetStudentPaymentsList(studentId));
                int i = -1;
                foreach (Payment payment in paymentList)
                {
                    i++;
                    studentInSubscriptionList = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && (x.StartDate > payment.StartDate && x.StartDate < payment.FinishDate || x.FinishDate < payment.FinishDate && x.FinishDate > payment.StartDate)).ToList();
                    for (int j = 0; j < studentInSubscriptionList.Count(); j++)

                    {
                        subscriptionNameList[i].Add(GSDE.Subscriptions.FirstOrDefault(x => x.Id == studentInSubscriptionList[j].Id).Name);
                    }
                    studentInSubscriptionListsList.Add(StudentInSubscriptionDTO.ConvertListToDTO(studentInSubscriptionList));

                }
                return subscriptionNameList;
            }
        }




        public static SubscriptionDTO GetCurrentSubscription(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                StudentInSubscription CurrentstudentInSubscription = new StudentInSubscription();
                CurrentstudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= DateTime.Now && x.FinishDate >= DateTime.Now).FirstOrDefault();
                Subscription currentSubscriptin = new Subscription();
                if (CurrentstudentInSubscription != default)
                {
                    currentSubscriptin = GSDE.Subscriptions.Where(x => x.Id == CurrentstudentInSubscription.SubscribtionId).FirstOrDefault();
                    return SubscriptionDTO.ConvertToDTO(currentSubscriptin);
                }
                else
                    return null;

            }


        }



        public static StudentInSubscriptionDTO GetCurrentStudentInSubscription(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                StudentInSubscription CurrentstudentInSubscription = new StudentInSubscription();
                CurrentstudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= DateTime.Now && x.FinishDate >= DateTime.Now).FirstOrDefault();
                if (CurrentstudentInSubscription == default)
                {
                    StudentInSubscriptionDTO studentInSubscriptionDTO = new StudentInSubscriptionDTO();
                   
                    return studentInSubscriptionDTO;
                }
                    return StudentInSubscriptionDTO.ConvertToDTO(CurrentstudentInSubscription);
            }


        }

        public static int GetCurrentWeekNum(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                int num;
                StudentInSubscription CurrentstudentInSubscription = new StudentInSubscription();
                CurrentstudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate <= DateTime.Now && x.FinishDate >= DateTime.Now).FirstOrDefault();
                if (CurrentstudentInSubscription !=default && CurrentstudentInSubscription.StartDate != null)
                {
                    var d = (DateTime.Now - (DateTime)CurrentstudentInSubscription.StartDate);
                    num = (int)d.Days / 7;
                    if (d.Days % 7 > 0)
                        num++;
                }
                else num = 0;
                return num;
            }


        }



        public static bool EditStudentInSubscription(StudentInSubscriptionDTO studentInSubscription)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {

                    var s = context.StudentInSubscriptions.FirstOrDefault(x => x.Id == studentInSubscription.Id);
                    if (s != null)
                    {
                        s.Id = studentInSubscription.Id;
                        s.StudentId = studentInSubscription.StudentId;
                        s.SubscribtionId = studentInSubscription.SubscribtionId;
                        s.StartDate = Convert.ToDateTime(studentInSubscription.StartDate);
                        s.FinishDate = Convert.ToDateTime(studentInSubscription.FinishDate);
                        context.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public static bool AddStudentInSubscription(StudentInSubscriptionDTO studentInSubscriptionDTO)
        {

            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {

                    StudentInSubscription studentInSubscription = StudentInSubscriptionDTO.ConvertFromDTO(studentInSubscriptionDTO);
                    Subscription subscription = GSDE.Subscriptions.Where(x => x.Id == studentInSubscription.SubscribtionId).FirstOrDefault();




                    if (studentInSubscription != default)
                    {
                        Convert.ToDateTime(studentInSubscription.StartDate);
                        studentInSubscription.FinishDate = studentInSubscription.StartDate;
                        studentInSubscription.FinishDate = Convert.ToDateTime(studentInSubscription.FinishDate).AddDays(7 * (double)subscription.WeeksNum);
                    }
                    var lastStudentInSubscriptions = GSDE.StudentInSubscriptions.Where(x => x.StartDate == studentInSubscription.StartDate).FirstOrDefault();
                    if (lastStudentInSubscriptions != default)
                    {
                        studentInSubscription.Id = lastStudentInSubscriptions.Id;
                        return EditStudentInSubscription(StudentInSubscriptionDTO.ConvertToDTO(studentInSubscription));
                    }

                    GSDE.StudentInSubscriptions.Add(studentInSubscription);
                    GSDE.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static bool AddStudentInSubscriptionUpToNow(int studentId)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    StudentInSubscription studentInSubscription = new StudentInSubscription();
                    var i = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.FinishDate<=DateTime.Now).Max(t => t.StartDate);
                    if (i == default) return false;
                    studentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentId && x.StartDate == i).First();


                    WeekFunction.AddWeeksUpTo(DateTime.Now);



                    // הוספת מנוי לתלמידה עד לתאריך נוכחי אלא אם עצרה מנוי או קבעה מנויי אחר
                   DateTime StartDate = (DateTime)studentInSubscription.FinishDate;
                    Subscription Subscription = new Subscription();
                    Subscription = GSDE.Subscriptions.Where(x => x.Id == studentInSubscription.SubscribtionId).FirstOrDefault();
                    var n = (double)((int)Subscription.WeeksNum * 7);
                    DateTime FinishDate = StartDate.AddDays(n);                    
                    while (studentInSubscription.Stop == false && studentInSubscription.FinishDate <= DateTime.Now &&
                        (GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentInSubscription.StudentId
                     && ((x.StartDate <= StartDate && x.FinishDate > StartDate)
                     || (x.StartDate > StartDate && x.StartDate < FinishDate)))
                         .FirstOrDefault() == default))
                    {
                        StudentInSubscription newStudentInSubscription = new StudentInSubscription();
                        newStudentInSubscription.StudentId = studentId;
                        newStudentInSubscription.SubscribtionId = studentInSubscription.SubscribtionId;
                        newStudentInSubscription.StartDate = studentInSubscription.FinishDate;
                        Subscription subscription = new Subscription();
                        subscription = GSDE.Subscriptions.Where(x => x.Id == newStudentInSubscription.StudentId).First();
                        newStudentInSubscription.FinishDate = ((DateTime)newStudentInSubscription.StartDate).AddDays((double)(7 * (int)subscription.WeeksNum));
                        newStudentInSubscription.Stop = false;
                        GSDE.StudentInSubscriptions.Add(newStudentInSubscription);
                        GSDE.SaveChanges();
                        newStudentInSubscription = GSDE.StudentInSubscriptions.OrderByDescending(o => o.Id).FirstOrDefault();
                        
                        //הוספת שיעורים לתלמידה עד לתאריך נוכחי
                        List<StudentInLesson> studentInLessonList = new List<StudentInLesson>();
                        studentInLessonList = GSDE.StudentInLessons.Where(x => x.StudentInSubscriptionId == studentInSubscription.Id).ToList()
                            .OrderByDescending(o => o.Date).Take((int)subscription.DaysInWeekNum).ToList();
                         
                        foreach (StudentInLesson studentInLesson in studentInLessonList)
                        {
                            for (int j = 0; j < subscription.WeeksNum; j++)
                            {
                                StudentInLesson newStudentInLessson = new StudentInLesson();
                                newStudentInLessson.StudentId = studentId;
                                newStudentInLessson.LessonId = studentInLesson.LessonId;
                                newStudentInLessson.Attendance = true;
                                newStudentInLessson.Date = ((DateTime)studentInLesson.Date).AddDays(7 * (j+1));
                                newStudentInLessson.StudentInSubscriptionId = newStudentInSubscription.Id;
                                var date2 = ((DateTime)newStudentInLessson.Date).AddDays(-7);
                                newStudentInLessson.WeekId = GSDE.Weeks
                                  .Where(x => x.Date <= newStudentInLessson.Date && x.Date >= date2).First().Id;
                                Student student = new Student();
                                student = GSDE.Students.Where(x => x.Id == studentId).First();


                                //טיפול בתשלום השיעור
                                Payment payment = new Payment();
                                int lessonPayment = (int)(subscription.Price / (subscription.WeeksNum * subscription.DaysInWeekNum));
                                student.Balance -= lessonPayment;
                                while (lessonPayment > 0)
                                {
                                    payment = GSDE.Payments.Where(x => x.StudentId == studentId && x.FinishDate == default).ToList().OrderBy(o => o.StartDate).FirstOrDefault();
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
                                            newStudentInLessson.PaymentId = payment.Id;
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
                                                newStudentInLessson.PaymentId = payment.Id;
                                            }
                                            break;
                                    }
                                }


                                studentInSubscription = newStudentInSubscription;
                                StartDate = (DateTime)studentInSubscription.FinishDate;
                                n=(double)((int)Subscription.WeeksNum * 7);
                                FinishDate = StartDate.AddDays(n);

                                GSDE.StudentInLessons.Add(newStudentInLessson);
                                GSDE.SaveChanges();
                            }

                        }




                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }


        }
        public static bool AddStudentInSubscriptionUpToNowForEvryStudent()
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    GSDE.Students.ToList().ForEach(x => AddStudentInSubscriptionUpToNow(x.Id));
                    return true;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }



        public static bool EditSubscription(int CurrentStudentInSubscriptionId, int SubscriptionId)
        {

            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    

                    StudentInSubscription lastStudentInSubscription = new StudentInSubscription();
                    lastStudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.Id == CurrentStudentInSubscriptionId).FirstOrDefault();
                    if (lastStudentInSubscription == default) return false;

                   
                    
                        lastStudentInSubscription.Stop = true;
                        GSDE.SaveChanges();



                        StudentInSubscription newStudentInSubscription = new StudentInSubscription();
                        newStudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StartDate == lastStudentInSubscription.FinishDate).FirstOrDefault();


                        if (newStudentInSubscription == default) return false;
                        while (newStudentInSubscription != default)
                        {
                        if (newStudentInSubscription.SubscribtionId != SubscriptionId)
                        {


                            //החזרת תשלום על שיעורים מוחלפים

                            Payment payment = new Payment();
                            Subscription LastSubscription = GSDE.Subscriptions.Where(x => x.Id ==newStudentInSubscription.SubscribtionId).FirstOrDefault();
                            if (LastSubscription == default) return false;
                            List <StudentInLesson> LeststudentInLessonList = new List<StudentInLesson>();
                            var LessonsToRemove = GSDE.StudentInLessons.Where(x => x.StudentInSubscriptionId == newStudentInSubscription.Id);
                            for (int i = 0; i < LessonsToRemove.Count(); i++)
                            {
                                payment.Balance += LastSubscription.Price / (LastSubscription.WeeksNum * LastSubscription.DaysInWeekNum);
                                GSDE.SaveChanges();
                            }

                            Student student = new Student();
                            student = GSDE.Students.Where(x => x.Id == lastStudentInSubscription.StudentId).FirstOrDefault();
                            if (student == default) return false;
                            student.Balance += LastSubscription.Price;
                            GSDE.SaveChanges();

                            Subscription subscription = new Subscription();
                            subscription = GSDE.Subscriptions.Where(x => x.Id == SubscriptionId).FirstOrDefault();
                            if (subscription == default || subscription.WeeksNum == default) return false;
                            newStudentInSubscription.FinishDate = ((DateTime)newStudentInSubscription.StartDate).AddDays(7 * (int)subscription.WeeksNum);
                            newStudentInSubscription.Stop = false;
                            GSDE.SaveChanges();

                            //מחיקת שיעורים קודמים
                          
                            GSDE.StudentInLessons.RemoveRange(LessonsToRemove);
                            GSDE.SaveChanges();
                            newStudentInSubscription.SubscribtionId = SubscriptionId;
                            GSDE.SaveChanges();
                        }
                       // else if (newStudentInSubscription.StudentInLessons.Where(x => x.LessonId == LessonId) != default) return true;

                        //יצירת שיעורים למנוי של תלמיד
                      // StudentInLessonFunction.CreateLessonListBySubscriptionIdLessonIdStudentInSubscriptionId((int)newStudentInSubscription.StudentId, LessonId, (DateTime)newStudentInSubscription.StartDate, (int)newStudentInSubscription.SubscribtionId, newStudentInSubscription.Id);

                        
                        newStudentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StartDate == newStudentInSubscription.FinishDate).FirstOrDefault();


                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        
        public static bool CreateStudentInSubscription(StudentInSubscriptionDTO studentInSubscriptionDTO)
        {

            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    DateTime StartDate = Convert.ToDateTime(studentInSubscriptionDTO.StartDate);
                    Subscription Subscription = new Subscription();
                    Subscription = GSDE.Subscriptions.Where(x => x.Id == studentInSubscriptionDTO.SubscribtionId).FirstOrDefault();
                    DateTime FinishDate = Convert.ToDateTime(studentInSubscriptionDTO.StartDate).AddDays((int)Subscription.WeeksNum*7);
                    if (GSDE.StudentInSubscriptions.Where(x => x.StudentId == studentInSubscriptionDTO.StudentId
                    && ((x.StartDate <= StartDate && x.FinishDate > StartDate)
                    || (x.StartDate > StartDate && x.StartDate < FinishDate)))
                         .FirstOrDefault() != default)
                        return false;


                    studentInSubscriptionDTO.StartDate = StartDate.ToString();
                    studentInSubscriptionDTO.FinishDate = FinishDate.ToString();
                    if (Subscription.WeeksNum % 4 == 0)
                        studentInSubscriptionDTO.Stop = false;
                    else
                        studentInSubscriptionDTO.Stop = true;
                    GSDE.StudentInSubscriptions.Add(StudentInSubscriptionDTO.ConvertFromDTO(studentInSubscriptionDTO));
                    
                    GSDE.SaveChanges();
          
                    }

                    return true;
                }
            
            catch (Exception e)
            {
                throw (e);
            }
        }
        
        public static ExceptionsEnum StopSubscriptionByDate(string Date)
        {

            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    DateTime date = Convert.ToDateTime(Date);
                    StudentInSubscription studentInSubscription = new StudentInSubscription();
                    studentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StartDate < date && x.FinishDate > date).FirstOrDefault();
                    if (studentInSubscription == default) return ExceptionsEnum.StudentInSubscriptionUndefine;
                    studentInSubscription.Stop = true;
                    GSDE.SaveChanges();
                    DateTime finishDate = Convert.ToDateTime(studentInSubscription.FinishDate);
                    int SubscribtionId = (int)studentInSubscription.SubscribtionId;
                    while (finishDate != default)
                    {
                        studentInSubscription = GSDE.StudentInSubscriptions.Where(x => x.StartDate == finishDate && x.SubscribtionId ==SubscribtionId).FirstOrDefault();
                        
                        if (studentInSubscription != default)
                        {
                            //מחיקת כל השיעורים שלו
                            GSDE.StudentInLessons.RemoveRange(GSDE.StudentInLessons.Where(x => x.StudentInSubscriptionId == studentInSubscription.Id));
                            GSDE.SaveChanges();
                            finishDate = Convert.ToDateTime(studentInSubscription.FinishDate);
                            SubscribtionId = (int)studentInSubscription.SubscribtionId;
                            GSDE.StudentInSubscriptions.Remove(studentInSubscription);
                            GSDE.SaveChanges();
                        }
                        else finishDate = default;

                    }
                }

                return ExceptionsEnum.True;
            }

            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}