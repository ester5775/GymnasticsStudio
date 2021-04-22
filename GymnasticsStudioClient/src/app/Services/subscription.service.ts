import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subscription } from '../classes/subscription';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  constructor(private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Subscription/';
  

  getSubscriptionList(StudentId:number):Observable<Subscription[]>
  {
     return this.http.get<Subscription[]>(this.studentUrl+"GetSubscriptionList/"+StudentId);
  }
}
