import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Student } from '../classes/student';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class StudentService {



  constructor( private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Student/'; 

  getStudentsList(): Observable<Student[]> {
    return this.http.get<Student[]>(this.studentUrl+"GetStudentsList");
  }

  getStudentsListByKind(studentKind:string): Observable<Student[]> {
    return this.http.get<Student[]>(this.studentUrl+"GetStudentsListByKind/"+studentKind);
  }

  getStudentsListByDetails(student:Student): Observable<Student[]> {
    return this.http.post<Student[]>(this.studentUrl+"GetStudentsListByDetails",student);
  }

  getStudentDetailsByStudentId(id:number): Observable<Student> {
    return this.http.get<Student>(this.studentUrl+"GetStudentDetailsByStudentId/"+id);
  }

  getBalance(id:number): Observable<number> {
    return this.http.get<number>(this.studentUrl+"GetBalance/"+id);
  }
  PostStudent(CurrentStudent: Student):Observable<boolean> {
    return this.http.post<boolean>(this.studentUrl+"EditStudent",CurrentStudent);
  }
}
