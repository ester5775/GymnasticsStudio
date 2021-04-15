import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { StudentService } from 'src/app/Services/student.service';
import { FormBuilder, FormGroup } from '@angular/forms';





  @Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {
  studentsKind:string;
  displayedColumns: string[] = ['Name','IdentityNumber', 'PhoneNumber'];  
  StudentsList:Array<Student>;
  student:Student;
  SearchForm:FormGroup;
  constructor(private route: ActivatedRoute,private router: Router, private studentService:StudentService,private formBuilder: FormBuilder) {
   
   }

  ngOnInit(): void {
    this.studentsKind=this.route.snapshot.paramMap.get('StudentKind');
    this.GetStudentsListByKind(this.studentsKind);
   
    this.SearchForm = this.formBuilder.group({
      firstName:[''],
      lastName:[''],    
      identityNumber:[''],
      phoneNumber:[''],
    });
    
  }

 

  GetStudentsListByKind(studentsKind:string)
  {
    
    this.studentService.getStudentsListByKind(studentsKind)
      .subscribe(studentsList => {
        this.StudentsList=studentsList;
      });
  }

 

  OpenStudentDetails(studentId:number){
    
   // this.student=element;
    this.router.navigateByUrl("students-list/"+this.studentsKind+"/(studentOptionsRouterOutlet:student-details/"+studentId+")");
  }


  OpenStudentPayDetails(studentId:number){
    
    this.router.navigateByUrl("customers/students-list/"+this.studentsKind+"/(studentOptionsRouterOutlet:student-pay-details/"+studentId+")");
  }

  OpenStudentScadul (studentId:number){
    
    this.router.navigateByUrl("customers/students-list/"+this.studentsKind+"/(studentOptionsRouterOutlet:student-scadul/"+studentId+")");
  }
  
  OpenStudentAttendanceScadul (studentId:number){
    
    this.router.navigateByUrl("customers/students-list/"+this.studentsKind+"/(studentOptionsRouterOutlet:student-attendance-scadul/"+studentId+")");
  }
  OpenStudentFiels(studentId:number){
    
    this.router.navigateByUrl("customers/students-fiels/"+this.studentsKind+"/(studentOptionsRouterOutlet:student-attendance-scadul/"+studentId+")");
  }
  logIn(){
    
    this.router.navigateByUrl("customers/log-in/(studentOptionsRouterOutlet:student-attendance-scadul)");
  }


  
search()
{
  this.student=new Student()
  this.student.FirstName=this.SearchForm.controls.firstName.value;
  this.student.LastName=this.SearchForm.controls.lastName.value;
  this.student.PhoneNumber=this.SearchForm.controls.phoneNumber.value;
  this.student.IdentityNumber=this.SearchForm.controls.identityNumber.value;

  this.studentService.getStudentsListByDetails(this.student)
  .subscribe(studentsList => {
    this.StudentsList=studentsList;
  });

};
}
  
  
  


 

