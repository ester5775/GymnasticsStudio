import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Week } from 'src/app/classes/week';
import { WeekService } from 'src/app/Services/week.service';

@Component({
  selector: 'app-week-details',
  templateUrl: './week-details.component.html',
  styleUrls: ['./week-details.component.css']
})
export class WeekDetailsComponent implements OnInit {

  
  id;
  week: Week;
  CurrentWeek = new Week ();
  SignUpForm = this.formBuilder.group({
    Date: new FormControl(''),
    Note: new FormControl(''),
    WeeklyPortion: new FormControl(''),
    
    
  });

  constructor(private weekService: WeekService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
   
    this.id = this.route.snapshot.paramMap.get('Id');
     this.getWeekDetailsByWeekId()
  }

  async getWeekDetailsByWeekId()
  {
    if (this.id != null && this.id != "") {

      if (this.id == "0")
      { 
        this.week= new Week();
        this.id= await this.weekService.AddWeek(this.week).toPromise();
      }
      this.weekService.getWeekDetailsByWeekId(this.id)
      .subscribe((res: Week) => {
        console.log("res: " + res)
        
        this.CurrentWeek = res
        
        this.BuildWeekDetailsForm();
      }, (error) => console.error)
  }
  }

  ngOnInit(): void {
    this.SignUpForm.disable()
  }


  BuildWeekDetailsForm() {
    this.SignUpForm.patchValue({
      Date: this.CurrentWeek.Date,
      Note: this.CurrentWeek.Note,
      WeeklyPortion: this.CurrentWeek.WeeklyPortion,
     

    })
  }
  Change() {
    this.SignUpForm.enable();
  }

  
  OnSubmit() {
    
    var week = new Week(this.SignUpForm.value);
    week.Id = this.id;
    this.weekService.PostWeek(week).subscribe(res => console.log(res),( err) =>{ console.log(err);
    this.router.navigate(['customers/subscriptions-of-students-details/'+"נשים"]);
    }
    )
  }
}

