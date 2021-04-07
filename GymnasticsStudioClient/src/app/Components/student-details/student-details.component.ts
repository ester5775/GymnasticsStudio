import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
  Id;
  
  
      SignUpForm = this.formBuilder.group({
      firstName:new FormControl(''),
      lastName:new FormControl(''),
      identityNumber:new FormControl(''),
      phjoneNumber:new FormControl(''),
    
      
    });


  constructor(private router:Router,private formBuilder: FormBuilder,private route: ActivatedRoute){
    this.Id=route.snapshot.paramMap.get('Id');
}
  

  async ngOnInit(): Promise<void> {
    await this.LoadClient();
    this.BuildStudentDetailsForm();
  }

  LoadClient()
  {
   this.student=new Student(
     this.Id,
    this.Id,
    this.Id,
    this.Id,
    this.Id,
    this.Id,
     this.Id,
    
   )
   
  }

  BuildStudentDetailsForm()
  {
    this.SignUpForm.patchValue({
      firstName:this.student.FirstName,
      lastName: this.student.LastName,
      identityNumber:this.student.IdentityNumber,
      phjoneNumber: this.student.PhoneNumber,
    
      // [Validators.required, Validators.pattern("[0-9 ]{12}")]
  })
  }

  



  OnSubmit()
  {
    
    console.log(this.SignUpForm.valid);
  }
  
}



