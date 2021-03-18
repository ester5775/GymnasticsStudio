import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Student } from 'src/app/classes/student';
import { BaseTreeControl, CdkTree, FlatTreeControl } from '@angular/cdk/tree';
import { PaymentService } from 'src/app/Services/payment.service';
import { Payment } from 'src/app/classes/payment';



@Component({
  selector: 'app-student-pay-details',
  templateUrl: './student-pay-details.component.html',
  styleUrls: ['./student-pay-details.component.css']
})


export class StudentPayDetailsComponent implements OnInit {
  PaymentList:Payment[];
  Id;
  lessonsCount:number=5;
  
  PayDetailsForm = this.formBuilder.group({
    manui:"פעם בשבוע",
    
  });

  constructor(private formBuilder: FormBuilder,private router: Router,private route: ActivatedRoute,private paymentService:PaymentService){
    this.Id=route.snapshot.paramMap.get('Id');}

  ngOnInit(): void {
    this.GetPaymentListByStudentId();
  }

  GetPaymentListByStudentId()
  {
    
    this.paymentService.getPaymentsListByStudentId(this.Id)
      .subscribe(paymentList => {
        this.PaymentList=paymentList;
      });
  }

  OnSubmit()
  {
    
    console.log(this.PayDetailsForm.valid);
  }
}
