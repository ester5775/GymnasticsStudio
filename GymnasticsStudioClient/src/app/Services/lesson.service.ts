
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lesson } from '../classes/lesson';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  constructor( private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Lesson/'; 

  getLessonsListBySubscriptionByStudentIdEndDate(StudentId:Number,Date:string): Observable<Lesson[]> {
    return this.http.get<Lesson[]>(this.studentUrl+"GetLessonsListBySubscriptionByStudentIdEndDate/"+StudentId+"/"+Date);
  }

}