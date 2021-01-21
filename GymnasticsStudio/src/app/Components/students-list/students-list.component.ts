import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { StudentService } from 'src/app/Services/student.service';



export interface PeriodicElement {
    name: string;
    phone: number;
  


}
  const ELEMENT_DATA: PeriodicElement[] = [
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
    { name: 'Hydrogen',phone: 1.0079 },
    { name: 'Helium', phone: 4.0026 },
    { name: 'Neon', phone: 20.1797},
  ];

  @Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'phone'];
  dataSource = ELEMENT_DATA;
  StudentsList:Array<Student>;
  student:Student;
  constructor(private route: ActivatedRoute,private router: Router, private studentService:StudentService) { }

  ngOnInit(): void {
    this.GetStudentsList()
  }

  GetStudentsList()
  {
    
    this.studentService.getStudentsList()
      .subscribe(studentsList => {
        this.StudentsList=studentsList;
      });
  }

 

  OpenStudentDetails(element){
    
    this.student=element;
    this.router.navigate(['studentDetailsRouterOutlet:student-details']);
  }

  OpenStudentPayDetails(){
    
    this.router.navigateByUrl("students-list/(studentPayDetailsRouterOutlet:student-pay-details)");
  }

}
  
  
  


 

