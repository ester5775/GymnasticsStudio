import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Teacher } from 'src/app/classes/teacher';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-teacher-details',
  templateUrl: './teacher-details.component.html',
  styleUrls: ['./teacher-details.component.css']
})
export class TeacherDetailsComponent implements OnInit {

 
  id;
  teacher:Teacher;
  CurrentTeacher = new Teacher ();
  SignUpForm = this.formBuilder.group({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    identityNumber: new FormControl(''),
    phoneNumber: new FormControl(''),
    
  });

  constructor(private teacherService: TeacherService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
   
    this.id = this.route.snapshot.paramMap.get('Id');
     this.getTeacherDetailsByTeacherId()
  }

  async getTeacherDetailsByTeacherId()
  {
    if (this.id != null && this.id != "") {

      if (this.id == "0")
      { 
        this.teacher= new Teacher();
        this.id= await this.teacherService.AddTeacher(this.teacher).toPromise();
      }
      this.teacherService.getTeacherDetailsByTeacherId(this.id)
      .subscribe((res: Teacher) => {
        console.log("res: " + res)
        debugger;
        this.CurrentTeacher = res
        debugger;
        this.BuildTeacherDetailsForm();
      }, (error) => console.error)
  }
}

  ngOnInit(): void {
    this.SignUpForm.disable()
  }


  BuildTeacherDetailsForm() {
    this.SignUpForm.patchValue({
      firstName: this.CurrentTeacher.FirstName,
      lastName: this.CurrentTeacher.LastName,
      identityNumber: this.CurrentTeacher.IdentityNumber,
      phoneNumber: this.CurrentTeacher.PhoneNumber,
     

    })
  }
  Change() {
    this.SignUpForm.enable();
  }

  
  OnSubmit() {
    debugger
    var teacher = new Teacher(this.SignUpForm.value);
    teacher.Id = this.id;
    this.teacherService.PostTeacher(teacher).subscribe(res => console.log(res), err => console.log(err))
  }
}

