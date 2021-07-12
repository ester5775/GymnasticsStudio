import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Teacher } from 'src/app/classes/teacher';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-teachers-list',
  templateUrl: './teachers-list.component.html',
  styleUrls: ['./teachers-list.component.css']
})
export class TeachersListComponent implements OnInit {

  
  displayedColumns: string[] = ['Name','IdentityNumber', 'PhoneNumber'];  
  TeacherList:Array<Teacher>;
  Teacher:Teacher;
  SearchForm:FormGroup;
  constructor(private route: ActivatedRoute,private router: Router, private TeacherService:TeacherService,private formBuilder: FormBuilder) {
   
   }

   ngOnInit(): void {
    
    this.GetTeacherList();
   
    this.SearchForm = this.formBuilder.group({
      firstName:[''],
      lastName:[''],    
      identityNumber:[''],
      phoneNumber:[''],
    });
    
  }

 

  GetTeacherList()
  {
    
    this.TeacherService.getTeacherList()
      .subscribe(TeacherList => {
        this.TeacherList=TeacherList;
      });
  }

 

  OpenTeacherDetails(TeacherId:number){
    
   // this.student=element;
    this.router.navigateByUrl("employees/teachers-list/(teacherOptionsRouterOutlet:edit-teacher/"+TeacherId+")");
  }


 
   
  AddTeacher(){
    
    this.router.navigateByUrl("employees/teachers-list/(teacherOptionsRouterOutlet:edit-teacher/0");
  }


  

}
  