import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { StudentService } from 'src/app/Services/student.service';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-edit-student-details',
  templateUrl: './edit-student-details.component.html',
  styleUrls: ['./edit-student-details.component.css']
})
export class EditStudentDetailsComponent implements OnInit {
  id;
  CurrentStudent=new Student();
  constructor(private studentService: StudentService, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe((params: Params) => {
      debugger
      this.id = params.id;
      if (this.id != null && this.id != "") {
        this.studentService.getStudentDetailsByStudentId(this.id)
          .subscribe((res: Student) => {
            debugger;
            console.log("res: " + res)
            this.CurrentStudent = res
          }
            , (error) => console.error)
      }
    });
  }
  ngOnInit(): void {
  }



}
