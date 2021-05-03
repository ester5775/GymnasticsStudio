
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lesson } from '../classes/lesson';
import { StudentInSubscription } from '../classes/student-in-subscription';

@Injectable({
  providedIn: 'root'
})
export class StudentInLessonService {

  constructor(private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/StudentInLesson/';
  

  PostStudentInLessons(lesson: Lesson,studentId:number,date:string):Observable<boolean> {
    return this.http.post<boolean>(this.studentUrl+"PostStudentInLessons/"+studentId+"/"+date,lesson);
  }
  }
