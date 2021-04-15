import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Student } from 'src/app/classes/student';
import { StudentService } from 'src/app/Services/student.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';



@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  
  
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

