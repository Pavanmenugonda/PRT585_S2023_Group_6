import { Component, OnInit } from '@angular/core';
import { Student } from '../models/student.model';


@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students: Student[] = [
    {id: '1',
    name: 'Md Habib',
    email: 'habibi@gmail.com',
    phone: 46364374,
    major: 'SE'
    },
    {id: '2',
    name: 'Md nurul',
    email: 'habibi@gmail.com',
    phone: 46364374,
    major: 'SE'
    }
  ];
  constructor(){
  }

  ngOnInit(): void {
    this.students.push()
      
  }
}
