
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Student } from 'src/app/classes/student';
import { BaseTreeControl, CdkTree, FlatTreeControl } from '@angular/cdk/tree';
import { PaymentService } from 'src/app/Services/payment.service';
import { Payment } from 'src/app/classes/payment';
import { promise } from 'selenium-webdriver';
import { StudentService } from 'src/app/Services/student.service';
import { StudentInSubscriptionService } from 'src/app/Services/student-in-subscription.service';
import { StudentInSubscription } from 'src/app/classes/student-in-subscription';



@Component({
  selector: 'app-student-pay-details',
  templateUrl: './student-pay-details.component.html',
  styleUrls: ['./student-pay-details.component.css']
})


export class StudentPayDetailsComponent implements OnInit {
  PaymentList:Payment[];
  StudentInSubscriptionNamesListByStudentId:string[][];
  Id;
  lessonsCount:number=5;
  state:string="יתרה";
  Balance:number;
  lastPayment:Payment;
  PayDetailsForm = this.formBuilder.group({
    manui:"פעם בשבוע",
    
  });

  constructor(private formBuilder: FormBuilder,private router: Router,private route: ActivatedRoute,private studentService:StudentService,private paymentService:PaymentService,private studentInSubscriptionService:StudentInSubscriptionService){
    this.Id=route.snapshot.paramMap.get('Id');}

  ngOnInit(): void {
    this.GetPaymentListByStudentId();
  }

   async GetPaymentListByStudentId()
  {
    
     
      
         this.PaymentList=await this.paymentService.getPaymentsListByStudentId(this.Id).toPromise();
         
         this.Balance=(await this.studentService.getStudentDetailsByStudentId(this.Id ).toPromise()).Balance;

         this.StudentInSubscriptionNamesListByStudentId=(await this.studentInSubscriptionService.getStudentInSubscriptionNamesListByStudentId(this.Id ).toPromise());

        

         if(this.Balance<0)
         {
         status="חוב";
         }
        // this.lastPayment = this.PaymentList.filter(
        //         payment => payment.FinishDate === '')[0];
        //         if (this.lastPayment.sum>)
  }
      

  OnSubmit()
  {
    
    console.log(this.PayDetailsForm.valid);
  }
}

