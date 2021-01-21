import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {


  student:Student;
 
  
  
      SignUpForm = this.formBuilder.group({
      firstName: '',
      lastName: '',
      identityNumber: '',
      phjoneNumber: '',
      mobilePhjoneNumber: '',
      
    });


  constructor(private formBuilder: FormBuilder,private route: ActivatedRoute){
}
  

  ngOnInit(): void {
   // this.LoadClient();
   // this.BuildStudentDetailsForm();
  }

  async LoadClient()
  {
   this.student=await new Student(
      1,
      this.route.snapshot.paramMap.get('student.FirstName'),
      this.route.snapshot.paramMap.get('student.LastName'),
      this.route.snapshot.paramMap.get('student.IdentityNumber'),
      this.route.snapshot.paramMap.get('student.PhoneNumber'),
      this.route.snapshot.paramMap.get('student.MobilePhoneNumber'),
      2
    )
   
  }

  BuildStudentDetailsForm()
  {
    this.SignUpForm=new FormGroup({
      firstName: new FormControl(this.student.FirstName),
      lastName: new FormControl(this.student.LastName),
      identityNumber:new FormControl(this.student.IdentityNumber),
      phjoneNumber: new FormControl(this.student.PhoneNumber),
      mobilePhjoneNumber: new FormControl(this.student.MobilePhoneNumber),
      // [Validators.required, Validators.pattern("[0-9 ]{12}")]
  })
  }

  OnSubmit()
  {
    
    console.log(this.SignUpForm.valid);
  }
  
}



