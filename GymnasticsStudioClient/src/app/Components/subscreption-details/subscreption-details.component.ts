import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'src/app/classes/subscription';
import { SubscriptionService } from 'src/app/Services/subscription.service';


@Component({
  selector: 'app-subscreption-details',
  templateUrl: './subscreption-details.component.html',
  styleUrls: ['./subscreption-details.component.css']
})
export class SubscreptionDetailsComponent implements OnInit {
  id;
  Subscription:Subscription;
  CurrentSubscription = new Subscription ();
  SignUpForm = this.formBuilder.group({
    Name: new FormControl(''),
    Price: new FormControl(''),
    WeeksNum: new FormControl(''),
    DaysInWeekNum: new FormControl(''),
    StudensKind: new FormControl(''),
    LessonKind: new FormControl(''),
  });

  constructor(private SubscriptionService:SubscriptionService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
   
    this.id = this.route.snapshot.paramMap.get('Id');
     this.getSubscriptionDetailsBySubscriptionId()
  }

  async getSubscriptionDetailsBySubscriptionId()
  {
    if (this.id != null && this.id != "") {

      if (this.id == "0")
      { 
        this.Subscription= new Subscription();
        this.id= await this.SubscriptionService.AddSubscription(this.Subscription).toPromise();
      }
      this.SubscriptionService.getSubscriptionDetailsBySubscriptionId(this.id)
      .subscribe((res: Subscription) => {
        console.log("res: " + res)
        
        this.CurrentSubscription = res
     
        this.BuildSubscriptionDetailsForm();
      }, (error) => console.error)
  }
}

  ngOnInit(): void {
    this.SignUpForm.disable()
  }


  BuildSubscriptionDetailsForm() {
    this.SignUpForm.patchValue({
     Name: this.CurrentSubscription.Name,
      Price: this.CurrentSubscription.Price,
      WeeksNum: this.CurrentSubscription.WeeksNum,
      DaysInWeekNum: this.CurrentSubscription.DaysInWeekNum,
      StudensKind: this.CurrentSubscription.StudensKind,
      LessonKind: this.CurrentSubscription.LessonKind,

    })
  }
  Change() {
    this.SignUpForm.enable();
  }

  
  OnSubmit() {
   
    var subscreption = new Subscription(this.SignUpForm.value);
    subscreption.Id = this.id;
    this.SubscriptionService.PostSubscription(subscreption).subscribe(res => console.log(res), err => console.log(err))
  }
}
