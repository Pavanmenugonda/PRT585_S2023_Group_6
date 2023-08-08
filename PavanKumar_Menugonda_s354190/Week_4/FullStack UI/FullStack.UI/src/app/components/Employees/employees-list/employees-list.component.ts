import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employees.model';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employees: Employee[] = [
    {
      id: '12',
      name: 'string',
     email :'string',
     phone:123456,
     salary: 9898,
     department: 'string',
    }
  ];

  constructor() {}

  ngOnInit(): void {

    this.employees.push()

  }

}
