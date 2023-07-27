import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit{
  // a list of employees
  employees: Employee[] = [
    {
      id: '1',
      name: 'John Doe',
      email: 'a@b.com',
      phone: '1234567890',
      salary: 10000,
      department: 'IT',
    },
    {
      id: '2',
      name: 'CR B',
      email: 'aaa@b.com',
      phone: '1234567890',
      salary: 10000,
      department: 'IT',
    },
    {
      id: '2',
      name: 'Sone A',
      email: 'accc@b.com',
      phone: '1234567890',
      salary: 10000,
      department: 'IT',
    },
  ];
  
  // constructor
  constructor() { }

  ngOnInit(): void {
    console.log('EmployeesListComponent: ngOnInit');
  }
}
