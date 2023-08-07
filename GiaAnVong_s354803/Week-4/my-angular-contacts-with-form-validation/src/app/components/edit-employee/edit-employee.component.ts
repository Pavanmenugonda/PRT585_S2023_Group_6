import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit{
  employeeDetail: Employee = {
    id: '',
    name: '',
    dateOfBirth: '',
    gender: '',
    email: '',
    phone: '',
    salary: 0,
    department: '',
  };

  constructor(private employeesService: EmployeesService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if(id){
          this.employeesService.getEmployee(id).subscribe({
            next: (employee) => {
              this.employeeDetail = employee;
            }
          })
        }

      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  UpdateEmployeeInfo() {
    this.employeesService.updateEmployee(this.employeeDetail.id, this.employeeDetail).subscribe({
      next: (employee) => {
        console.log(employee);
        this.router.navigate(['employees']);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  DeleteEmployeeInfo() {
    this.employeesService.deleteEmployee(this.employeeDetail.id).subscribe({
      next: (employee) => {
        console.log(employee);
        this.router.navigate(['employees']);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
