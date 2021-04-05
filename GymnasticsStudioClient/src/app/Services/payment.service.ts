import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Payment } from '../classes/payment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor( private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Payment/'; 

  getPaymentsListByStudentId(Id:Number): Observable<Payment[]> {
    return this.http.get<Payment[]>(this.studentUrl+"GetPaymentsListByStudentId/${Id}");
  }
}
