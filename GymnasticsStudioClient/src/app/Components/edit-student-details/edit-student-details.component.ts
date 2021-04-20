import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { StudentService } from 'src/app/Services/student.service';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { MatCardModule } from '@angular/material/card';
import { FormBuilder, FormControl } from '@angular/forms';

@Component({
  selector: 'app-edit-student-details',
  templateUrl: './edit-student-details.component.html',
  styleUrls: ['./edit-student-details.component.css']
})
export class EditStudentDetailsComponent implements OnInit {
  id;
  CurrentStudent = new Student();
  SignUpForm = this.formBuilder.group({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    identityNumber: new FormControl(''),
    phjoneNumber: new FormControl(''),


  });

  constructor(private studentService: StudentService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id != null && this.id != "") {
      this.studentService.getStudentDetailsByStudentId(this.id)
        .subscribe((res: Student) => {
          debugger;
          console.log("res: " + res)
          this.CurrentStudent = res
        }, (error) => console.error)
    }
  }

  ngOnInit(): void {
    this.BuildStudentDetailsForm();
    this.OnSubmit()
  }


  BuildStudentDetailsForm() {
    this.SignUpForm.patchValue({
      firstName: this.CurrentStudent.FirstName,
      lastName: this.CurrentStudent.LastName,
      identityNumber: this.CurrentStudent.IdentityNumber,
      phoneNumber: this.CurrentStudent.PhoneNumber,
    })
  }
  Change() {
    this.SignUpForm.disabled;
  }
  OnSubmit(){
    this.studentService.PostStudent(this.CurrentStudent).subscribe(res=>console.log(res),err=>console.log(err))
  }
}
