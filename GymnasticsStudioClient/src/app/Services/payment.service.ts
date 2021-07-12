import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Payment } from '../classes/payment';
import { SubscreptionOfPaymentDTO } from '../classes/subscreption-of-payment-dto';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor( private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Payment/'; 

  getPaymentsListByStudentId(Id:Number): Observable<Payment[]> {
    return this.http.get<Payment[]>(this.studentUrl+"GetPaymentsListByStudentId/"+Id);
  }
  
  getSubscreptionOfPaymentListByStudentId(Id:Number): Observable<SubscreptionOfPaymentDTO[]> {
    return this.http.get<SubscreptionOfPaymentDTO[]>(this.studentUrl+"GetSubscreptionOfPaymentListByStudentId/"+Id);
  }


  
  getPaymentDetailsByPaymentId(id:number): Observable<Payment> {
    return this.http.get<Payment>(this.studentUrl+"GetPaymentDetailsByPaymentId/"+id);
  }

 
  PostPayment(Payment:Payment):Observable<boolean> {
    return this.http.post<boolean>(this.studentUrl+"EditPayment",Payment);
  }

  AddPayment(Payment:Payment):Observable<number> {
    return this.http.put<number>(this.studentUrl+"AddPayment",Payment);
  }

  
 
}



