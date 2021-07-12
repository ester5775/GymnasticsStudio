import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../classes/student';
import { StudentInSubscription } from '../classes/student-in-subscription';
import { Subscription } from '../classes/subscription';
import { ExceptionsEnum } from '../Enums/exceptions-enum.enum';

@Injectable({
  providedIn: 'root'
})
export class StudentInSubscriptionService {

  constructor(private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/StudentInSubscription/';
  
  
  getStudentInSubscriptionListByStudentId(id:number): Observable<StudentInSubscription[][]> {
    return this.http.get<StudentInSubscription[][]>(this.studentUrl+"GetStudentInSubscriptionListByStudentId/"+id);
  }

  getStudentInSubscriptionNamesListByStudentId(id:number): Observable<string[][]> {
    return this.http.get<string[][]>(this.studentUrl+"GetStudentInSubscriptionNamesListByStudentId/"+id);
  }


  getCurrentSubscription(id:Number): Observable<Subscription> {
    return this.http.get<Subscription>(this.studentUrl+"GetCurrentSubscription/"+id);
  }

  getCurrentStudentInSubscription(id:Number): Observable<StudentInSubscription> {
    return this.http.get<StudentInSubscription>(this.studentUrl+"GetCurrentStudentInSubscription/"+id);
  }

  getCurrentWeekNum(id:Number): Observable<number> {
    return this.http.get<number>(this.studentUrl+"GetCurrentWeekNum/"+id);
  }

  PostStudentInSubscription(studentInSubscription: StudentInSubscription):Observable<boolean> {
    return this.http.post<boolean>(this.studentUrl+"EditStudentInSubscription", studentInSubscription);
  }

  AddStudentInSubscription(studentInSubscription: StudentInSubscription):Observable<boolean> {
    return this.http.put<boolean>(this.studentUrl+"AddStudentInSubscription", studentInSubscription);
  }

  
  AddStudentInSubscriptionUpToNowForEvryStudent():Observable<boolean> {
    return this.http.get<boolean>(this.studentUrl+"AddStudentInSubscriptionUpToNowForEvryStudent");
  }

  EditSubscription(CurrentStudentInSubscriptionId:number,subscriptionId:number):Observable<boolean> {
    return this.http.get<boolean>(this.studentUrl+"EditSubscription/"+CurrentStudentInSubscriptionId+"/"+subscriptionId);
  }

  CreateStudentInSubscription(StudetInSubsctiption:StudentInSubscription):Observable<boolean> {
    return this.http.post<boolean>(this.studentUrl+"CreateStudentInSubscription",StudetInSubsctiption);
  }

  StopSubscriptionByDate(date:string):Observable<ExceptionsEnum> {
    return this.http.get<ExceptionsEnum>(this.studentUrl+"StopSubscriptionByDate/"+date);
  }

}
