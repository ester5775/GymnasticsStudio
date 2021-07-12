
       
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './Components/log-in/log-in.component';
import { StudentPayDetailsComponent } from './Components/student-pay-details/student-pay-details.component';
import { CustomersComponent } from './Components/customers/customers.component';
import { ManagerComponent } from './Components/manager/manager.component';
import { StudentsFilesComponent } from './Components/students-files/students-files.component';
import { EditStudentDetailsComponent } from './Components/edit-student-details/edit-student-details.component';



import { MatSnackBarModule } from '@angular/material/snack-bar';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTabsModule} from '@angular/material/tabs';
import { MatMenuModule} from '@angular/material/menu';
import { StudentsListComponent } from './Components/students-list/students-list.component';
import { MatTableModule} from '@angular/material/table';
import { ScrollingModule} from '@angular/cdk/scrolling';
import { StudentDetailsComponent } from './Components/student-details/student-details.component';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatSelectModule} from '@angular/material/select';
import { MatInputModule} from '@angular/material/input';
import { MatOptionModule } from '@angular/material/core';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatTreeModule} from '@angular/material/tree';
import {MatListModule} from '@angular/material/list';
import {MatDialogModule} from '@angular/material/dialog';
import {MatCheckboxModule} from '@angular/material/checkbox';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { StudentScadulComponent } from './Components/student-scadul/student-scadul.component';
import { StudentAttendanceScadulComponent } from './Components/student-attendance-scadul/student-attendance-scadul.component';


import { from } from 'rxjs';
import { DateDialogBoxComponent } from './Components/date-dialog-box/date-dialog-box.component';
import { ParticularSubscriptionDialgBoxComponent } from './Components/particular-subscription-dialg-box/particular-subscription-dialg-box.component';
import  {  PdfViewerModule  }  from  'ng2-pdf-viewer';
import { ScadulComponent } from './Components/scadul/scadul.component';
import { SubscriptionsOfStudentsDetailsComponent } from './Components/subscriptions-of-students-details/subscriptions-of-students-details.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { EmployeesComponent } from './Components/employees/employees.component';
import { LessonComponent } from './Components/lesson/lesson.component';
import { LessonsListComponent } from './Components/lessons-list/lessons-list.component';
import { LessonDetailsComponent } from './Components/lesson-details/lesson-details.component';

import { PaymentDetailsComponent } from './Components/payment-details/payment-details.component';
import { TeacherDetailsComponent } from './Components/teacher-details/teacher-details.component';
import { TeachersListComponent } from './Components/teachers-list/teachers-list.component';
import { SubscreptionDetailsComponent } from './Components/subscreption-details/subscreption-details.component';
import { SubscreptionComponent } from './Components/subscreption/subscreption.component';
import { SubscreptionsListComponent } from './Components/subscreptions-list/subscreptions-list.component';
import { WeekDetailsComponent } from './Components/week-details/week-details.component';
import { AddPaymentListComponent } from './Components/add-payment-list/add-payment-list.component';
// import { MaskedTextBoxModule } from '@progress/kendo-angular-inputs';


@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    StudentsListComponent,
    StudentDetailsComponent,
    StudentPayDetailsComponent,
    StudentScadulComponent,
    StudentAttendanceScadulComponent,
    CustomersComponent,
    ManagerComponent,
    TeachersListComponent,
    SubscreptionDetailsComponent,
    StudentsFilesComponent,
    WeekDetailsComponent,
    
    EditStudentDetailsComponent,
    DateDialogBoxComponent,
    ParticularSubscriptionDialgBoxComponent,
    ScadulComponent,
    SubscriptionsOfStudentsDetailsComponent,
    EmployeesComponent,
    LessonComponent,
    LessonsListComponent,
    LessonDetailsComponent,
    SubscreptionComponent,
    SubscreptionsListComponent,
    PaymentDetailsComponent,
    
    TeacherDetailsComponent,
    
    AddPaymentListComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([]),
    FormsModule,
    ReactiveFormsModule,

    MatToolbarModule,
    MatIconModule,
    MatSliderModule,
    MatButtonModule,
    MatCardModule,
    MatTabsModule,
    MatMenuModule,
    MatTableModule,
    ScrollingModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatOptionModule,
    MatGridListModule,
    MatExpansionModule,
    MatTreeModule,
    CommonModule,
    MatListModule,
    MatDialogModule,
    MatCheckboxModule,
    MatSnackBarModule,
    //MaskedTextBoxModule,
    HttpClientModule,
    PdfViewerModule,


  ],
  
  exports: [ 
    
    MatToolbarModule,
    MatIconModule,
    MatSliderModule,
    MatButtonModule,
    MatCardModule,
    MatTabsModule,
    MatMenuModule,
    MatTableModule,
    ScrollingModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatOptionModule,
    MatGridListModule,
    MatExpansionModule,
    MatTreeModule,
    CommonModule,
    MatListModule,
    MatDialogModule,
    MatCheckboxModule,
    MatSnackBarModule
  ],
 
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


