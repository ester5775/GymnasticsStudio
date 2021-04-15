import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { StudentService } from './Services/student.service';
import { Student } from './classes/student';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GymnasticsStudio'; 
  StudentsList:Array<Student>; 
  
  ngOnInit(): void {
    this.GetStudentsList()
  }

  GetStudentsList()
  {
    
    this.studentService.getStudentsList()
      .subscribe(studentsList => {
        this.StudentsList=studentsList;
      });
  }
  constructor(private studentService:StudentService,private route: ActivatedRoute,private router: Router,public sanitizer: DomSanitizer) { }

ShowStudentsList(studentKind:string)
  {
    this.router.navigate(['']);
    this.router.navigate(['customers/students-list/'+studentKind]);
  }

  
}