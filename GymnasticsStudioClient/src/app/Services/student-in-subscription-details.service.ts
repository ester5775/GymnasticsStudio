import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentInSubscripyionDetailsList } from '../classes/student-in-subscripyion-details-list';

@Injectable({
  providedIn: 'root'
})
export class StudentInSubscriptionDetailsService {

  constructor(private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/StudentInSubscriptionDetails/'; 

  getStudentInSubscriptionDetailsListListBystudentKind(studentKind:string): Observable<StudentInSubscripyionDetailsList[]> {
    return this.http.get<StudentInSubscripyionDetailsList[]>(this.studentUrl+"GetStudentInSubscriptionDetailsListListBystudentKind/"+studentKind);
  }

  
}
