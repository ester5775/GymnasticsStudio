using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class PaymentFunction
    {

        public static List<PaymentDTO> GetStudentPaymentsList(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Payment> paymentList = new List<Payment>();
                paymentList = GSDE.Payments.Where(x=>x.StudentId==studentId).ToList();
                return PaymentDTO.ConvertListToDTO(paymentList);


            }
        }


        public static PaymentDTO GetPaymentDetailsByPaymentId(int id)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                Payment Payment = new Payment();
                Payment = GSDE.Payments.FirstOrDefault(x => x.Id == id);
                return PaymentDTO.ConvertToDTO(Payment);


            }
        }

        //public static bool EditPayment(PaymentDTO PaymentDTO)
        //{
        //    using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
        //    {

        //        var Payment = context.Payments.FirstOrDefault(x => x.Id == PaymentDTO.Id);
        //        if (Payment != null)
        //        {
        //            Payment.Sum = PaymentDTO.Sum;
        //            Payment.StartDate = Convert.ToDateTime(PaymentDTO.StartDate);
        //            Payment.FinishDate = Convert.ToDateTime(PaymentDTO.FinishDate);
        //            Payment.FormOfPayment = PaymentDTO.FormOfPayment?.TrimStart().TrimEnd();
        //            Payment.StudentId = PaymentDTO.StudentId;
        //            Payment.Balance = PaymentDTO.Balance;

        //            context.SaveChanges();
        //            return true;
        //        }
        //        else return false;
        //    }


        //}

        public static int AddPayment(PaymentDTO PaymentDTO)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {



                    Payment Payment = new Payment();
                    Payment.Sum = PaymentDTO.Sum;
                    Payment.StartDate = Convert.ToDateTime(PaymentDTO.StartDate);
                    Payment.FinishDate = Convert.ToDateTime(PaymentDTO.FinishDate);
                    Payment.FormOfPayment = PaymentDTO.FormOfPayment?.TrimStart().TrimEnd();
                    Payment.StudentId = PaymentDTO.StudentId;
                    Payment.Balance = PaymentDTO.Balance;
                    Student student= context.Students.Where(x => x.Id == Payment.StudentId).First();
                   
                    context.Payments.Add(Payment);
                    context.SaveChanges();

                    int paymentId=context.Payments.Max(o => o.Id);

                    student.Balance += Payment.Balance;
                    context.SaveChanges();

                    List<Payment> debtList = context.Payments.Where(x => x.StudentId == Payment.StudentId && x.Sum < 0).ToList();
                    int i = 0;
                    while (debtList.Count > i&& Payment.Balance>0 - debtList[i].Balance)
                    {
                        Payment.Balance += debtList[i].Balance;                        
                        int d = debtList[i].Id;
                        List<StudentInLesson> studentInLessonList = context.StudentInLessons.Where(x => x.PaymentId == d).ToList();
                        for (int j = 0; j < studentInLessonList.Count; j++)
                        {
                            studentInLessonList[j].PaymentId = paymentId;
                            context.SaveChanges();
                        }
                        context.Payments.Remove(debtList[i]);
                        context.SaveChanges();
                        i++;
                    }
                    
                    return paymentId;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }



        public static List<PaymentDTO> getPaymentList()
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Payment> PaymentList = new List<Payment>();
                PaymentList = GSDE.Payments.ToList();
                return PaymentDTO.ConvertListToDTO(PaymentList);
            }
        }

    }
}
