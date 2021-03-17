import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { StudentService } from 'src/app/Services/student.service';






  @Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'phone'];  
  StudentsList:Array<Student>;
  student:Student;
  constructor(private route: ActivatedRoute,private router: Router, private studentService:StudentService) { }

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

 

  OpenStudentDetails(studentId:number){
    
   // this.student=element;
    this.router.navigateByUrl("students-list/(studentOptionsRouterOutlet:student-details/"+studentId+")");
  }


  OpenStudentPayDetails(studentId:number){
    
    this.router.navigateByUrl("students-list/(studentOptionsRouterOutlet:student-pay-details/"+studentId+")");
  }

  OpenStudentScadul (studentId:number){
    
    this.router.navigateByUrl("students-list/(studentOptionsRouterOutlet:student-scadul/"+studentId+")");
  }
  
  OpenStudentAttendanceScadul (studentId:number){
    
    this.router.navigateByUrl("students-list/(studentOptionsRouterOutlet:student-attendance-scadul/"+studentId+")");
  }

}
  
  
  


 

