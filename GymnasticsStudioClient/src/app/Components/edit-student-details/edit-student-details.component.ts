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
    phoneNumber: new FormControl(''),
    HMO: new FormControl(''),
    CreditCardNumber: new FormControl(''),
    Comments: new FormControl(''),
    Addrees: new FormControl(''),
    BirthDay: new FormControl(''),
    StartDate: new FormControl(''),
  });

  constructor(private studentService: StudentService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
    this.id = this.route.snapshot.paramMap.get('Id');
    if (this.id != null && this.id != "") {
      this.studentService.getStudentDetailsByStudentId(this.id)
        .subscribe((res: Student) => {
          console.log("res: " + res)
          debugger;
          this.CurrentStudent = res
          debugger;
          this.BuildStudentDetailsForm();
        }, (error) => console.error)
    }
  }

  ngOnInit(): void {
    this.SignUpForm.disable()
  }


  BuildStudentDetailsForm() {
    this.SignUpForm.patchValue({
      firstName: this.CurrentStudent.FirstName,
      lastName: this.CurrentStudent.LastName,
      identityNumber: this.CurrentStudent.IdentityNumber,
      phoneNumber: this.CurrentStudent.PhoneNumber,
      HMO: this.CurrentStudent.HMO,
      CreditCardNumber: this.CurrentStudent.CreditCardNumber,
      Comments: this.CurrentStudent.Comments,
      Addrees: this.CurrentStudent.Addrees,
      BirthDay: this.CurrentStudent.BirthDay,
      StartDate: this.CurrentStudent.StartDate,

    })
  }
  Change() {
    this.SignUpForm.enable();
  }
  OnSubmit() {
    debugger
    var stu = new Student(this.SignUpForm.value);
    stu.Id = this.id;
    this.studentService.PostStudent(stu).subscribe(res => console.log(res), err => console.log(err))
  }
}
