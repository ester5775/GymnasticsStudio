import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { FormBuilder } from '@angular/forms';
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
  SearchForm = this.formBuilder.group({
    Search:''
  });
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
  constructor(private studentService:StudentService,private formBuilder: FormBuilder,private route: ActivatedRoute,private router: Router,public sanitizer: DomSanitizer) { }

ShowStudentsList()
  {
    this.router.navigate(['students-list']);
  }

  OnSubmit()
  {
    
    console.log(this.SearchForm.valid);
  }
}