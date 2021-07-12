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
  

  getSubscriptionListByStudent(StudentId:number):Observable<Subscription[]>
  {
     return this.http.get<Subscription[]>(this.studentUrl+"getSubscriptionListByStudent/"+StudentId);
  }


  

  getSubscriptionDetailsBySubscriptionId(id:number): Observable<Subscription> {
    return this.http.get<Subscription>(this.studentUrl+"GetSubscriptionDetailsBySubscriptionId/"+id);
  }

 
  PostSubscription(Subscription:Subscription):Observable<boolean> {
    return this.http.post<boolean>(this.studentUrl+"EditSubscription",Subscription);
  }

  AddSubscription(Subscription:Subscription):Observable<number> {
    return this.http.put<number>(this.studentUrl+"AddSubscription",Subscription);
  }

  
  getSubscriptionList(): Observable<Subscription[]> {
    return this.http.get<Subscription[]>(this.studentUrl+"getSubscriptionList");
  }
}

