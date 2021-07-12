import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl,FormArray, FormBuilder } from '@angular/forms'
import { Payment } from 'src/app/classes/payment';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-add-payment-list',
  templateUrl: './add-payment-list.component.html',
  styleUrls: ['./add-payment-list.component.css']
})
export class AddPaymentListComponent {

  title = 'FormArray Example in Angular Reactive forms';
  PaymentList:Payment[]
  skillsForm: FormGroup;
 
  constructor(private fb:FormBuilder,private paymentService:PaymentService) {
 
    this.skillsForm = this.fb.group({
      
      skills: this.fb.array([]) ,
    });
  
  }
 
  get skills() : FormArray {
    return this.skillsForm.get("skills") as FormArray
  }
 
  newSkill(): FormGroup {
    return this.fb.group({
      StudentId: '',
      Sum: '',
      FormOfPayment: '',
      Date:'',

    })
  }
 
  addSkills() {
    for(let i = 0; i < 5; i++)
    this.skills.push(this.newSkill());
  }
 
  // removeSkill(i:number) {
  //   this.skills.removeAt(i);
  // }
 
  onSubmit() {

    for (let control of this.skills.controls)
    {
      var payment= new Payment();
      payment.StartDate=control.value.Date;
      
      payment.StudentId=control.value.StudentId;
      payment.Sum=control.value.Sum;
      payment.Balance=control.value.Sum;
      payment.FormOfPayment=control.value.FormOfPayment;     
      this.paymentService.AddPayment(payment).subscribe(res => console.log(res)
      
      , err => console.log(err));
    }
    this.skills.clear();
    
  }
 
}
 
 
export class country {
  id: string;
  name: string;
 
  constructor(id: string, name: string) {
    this.id = id;
    this.name = name;
  }
}
 