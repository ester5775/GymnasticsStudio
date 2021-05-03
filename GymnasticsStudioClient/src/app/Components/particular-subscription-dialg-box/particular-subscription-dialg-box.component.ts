import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ParticularSubscription } from 'src/app/classes/particular-subscription';

@Component({
  selector: 'app-particular-subscription-dialg-box',
  templateUrl: './particular-subscription-dialg-box.component.html',
  styleUrls: ['./particular-subscription-dialg-box.component.css']
})
export class ParticularSubscriptionDialgBoxComponent implements OnInit {

  constructor( 
    public dialogRef: MatDialogRef<ParticularSubscriptionDialgBoxComponent>,
    @Inject(MAT_DIALOG_DATA) public data:ParticularSubscription) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }


}
