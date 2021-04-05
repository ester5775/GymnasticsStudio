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

  getStudentDetailsByStudentId(): Observable<Student[]> {
    return this.http.get<Student[]>(this.studentUrl+"getStudentDetailsByStudentId/${Id}");
  }
}
