﻿
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    class PaymentDTO
    {
        public int Id { get; set; }
        public Nullable<int> Sum { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string FormOfPayment { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }



        public static PaymentDTO Convert(Payment payment)
        {
            PaymentDTO paymentDTO = new PaymentDTO();
            paymentDTO.Id = payment.Id;
            paymentDTO.Sum = payment.Sum;
            paymentDTO.StudentId = payment.StudentId;
            paymentDTO.FormOfPayment = payment.FormOfPayment;
            paymentDTO.StartDate = payment.StartDate;
            paymentDTO.FinishDate = payment.FinishDate;

            return paymentDTO;
        }

        public static List<PaymentDTO> Convert(List<Payment> paymentList)
        {
            return paymentList.Select(x => Convert(x)).ToList();
        }

        public static Payment Convert(PaymentDTO paymentDTO)
        {
            Payment payment = new Payment();
            payment.Id = paymentDTO.Id;
            payment.Sum = paymentDTO.Sum;
            payment.StudentId = paymentDTO.StudentId;
            payment.FormOfPayment = paymentDTO.FormOfPayment;
            payment.StartDate = paymentDTO.StartDate;
            payment.FinishDate = paymentDTO.FinishDate;

            return payment;
        }

        public static List<Payment> Convert(List<PaymentDTO> paymentDTOsList)
        {
            return paymentDTOsList.Select(x => Convert(x)).ToList();

        }

    }
}
