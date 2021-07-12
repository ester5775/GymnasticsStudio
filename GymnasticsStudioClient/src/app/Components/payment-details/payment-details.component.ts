import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Payment } from 'src/app/classes/payment';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.css']
})
export class PaymentDetailsComponent implements OnInit {

   
  StudentId;
  payment: Payment;
  CurrentPayment = new Payment ();
  SignUpForm = this.formBuilder.group({
    Sum: new FormControl(''),
    StudentId: new FormControl(''),
    StartDate: new FormControl(''),
    FormOfPayment: new FormControl(''),
    Balance: new FormControl(''),
  
   
  });

  constructor(private paymentService: PaymentService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
   
    this.StudentId = this.route.snapshot.paramMap.get('Id');
     
  }

  
  

  ngOnInit(): void {
    this.SignUpForm.disable()
  }


  BuildPaymentDetailsForm() {
    this.SignUpForm.patchValue({
      Sum: this.CurrentPayment.Sum,
      StudentId: this.StudentId,
      StartDate: this.CurrentPayment.StartDate,
      FormOfPayment: this.CurrentPayment.FormOfPayment,
      Balance: this.CurrentPayment.Balance,
     

    })
  }
  Change() {
    this.SignUpForm.enable();
  }

  
  OnSubmit() {
    
    var payment = new Payment(this.SignUpForm.value);
    
    this.paymentService.AddPayment(payment).subscribe(data => console.log(data))
  }
}

