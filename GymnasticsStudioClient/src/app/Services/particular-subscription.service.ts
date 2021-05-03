import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ParticularSubscription } from '../classes/particular-subscription';

@Injectable({
  providedIn: 'root'
})
export class ParticularSubscriptionService {

  constructor( private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/ParticularSubscription/'; 


  AddParticularSubscription(ParticularSubscription:ParticularSubscription):Observable<boolean> {
    return this.http.put<boolean>(this.studentUrl+"AddParticularSubscription", ParticularSubscription);
  }
  
}
