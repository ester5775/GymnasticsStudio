import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-date-dialog-box',
  templateUrl: './date-dialog-box.component.html',
  styleUrls: ['./date-dialog-box.component.css']
})
export class DateDialogBoxComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DateDialogBoxComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {Date:string}) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }

}
