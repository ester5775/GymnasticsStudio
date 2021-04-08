import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/classes/student';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-edit-student-details',
  templateUrl: './edit-student-details.component.html',
  styleUrls: ['./edit-student-details.component.css']
})
export class EditStudentDetailsComponent implements OnInit {
  Id;
  CurrentStudent;
  constructor(private studentService:StudentService) {
   }
  ngOnInit(): void {
    if(this.Id!=null&&this.Id!=""){
    this.studentService.getStudentDetailsByStudentId(this.Id)
    .subscribe((res:Student)=>{
      console.log("res: "+res)
      this.CurrentStudent=res
    }
      ,(error)=>console.error)
    }
  }

}
