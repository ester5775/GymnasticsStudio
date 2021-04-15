import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../classes/student';
import { StudentInSubscription } from '../classes/student-in-subscription';

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
}
