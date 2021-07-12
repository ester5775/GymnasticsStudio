
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
import { SubscreptionOfPaymentDTO } from 'src/app/classes/subscreption-of-payment-dto';



@Component({
  selector: 'app-student-pay-details',
  templateUrl: './student-pay-details.component.html',
  styleUrls: ['./student-pay-details.component.css']
})


export class StudentPayDetailsComponent implements OnInit {
  PaymentList:Payment[];
  StudentInSubscriptionNamesListByStudentId:string[][];
  
  lessonsCount:number=5;
  state:string="יתרה";
  Balance:number;
  lastPayment:Payment;
  SubscreptionOfPaymentList:SubscreptionOfPaymentDTO[];
  Payment:Payment;
  studentsKind;
  studentId

  constructor(private formBuilder: FormBuilder,private router: Router,private route: ActivatedRoute,private studentService:StudentService,private paymentService:PaymentService,private studentInSubscriptionService:StudentInSubscriptionService){
    this.studentId=route.snapshot.paramMap.get('Id');
    this.studentsKind=route.snapshot.paramMap.get('StudentKind');
  }

  ngOnInit(): void {
    this.GetPaymentListByStudentId();
  }

   async GetPaymentListByStudentId()
  {
    
     
      
         this.PaymentList=await this.paymentService.getPaymentsListByStudentId(this.studentId).toPromise();
         
         this.Balance=(await this.studentService.getStudentDetailsByStudentId(this.studentId ).toPromise()).Balance;
         
         this.SubscreptionOfPaymentList=await this.paymentService.getSubscreptionOfPaymentListByStudentId(this.studentId).toPromise();
         
        

         if(this.Balance<0)
         {
         status="חוב";
         }
        
  }

  
  async AddPayment()
  {
    this.router.navigateByUrl("customers/students-list/"+this.studentsKind+"/(studentOptionsRouterOutlet:student-pay-details/"+this.studentId+"/edit-payment)");
  }
   
   
  

  OnSubmit()
  {
    
   
  }
}

