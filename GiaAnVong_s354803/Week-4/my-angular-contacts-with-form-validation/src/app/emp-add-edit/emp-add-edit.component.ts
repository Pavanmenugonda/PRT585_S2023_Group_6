import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeesService } from 'src/app/services/employees.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-emp-add-edit',
  templateUrl: './emp-add-edit.component.html',
  styleUrls: ['./emp-add-edit.component.css']
})

export class EmpAddEditComponent {
  empForm: FormGroup;

  constructor(private employeesService: EmployeesService, private router: Router, private _formBuilder: FormBuilder) { 
    this.empForm = this._formBuilder.group({
      name:'',
      dateOfBirth:'',
      gender:'',
      email: ['', [Validators.required, Validators.email]], // Adding email validation
      phone:'',
      salary:'',
      department:'',
    })
  }

  onFormSubmit() {
    // console.log(this.empForm.value);
    if(this.empForm.valid) {
      // console.log('empForm',this.empForm.value);
      this.addEmployee();
    }
  }

  addEmployee(): void {
    console.log('empForm',this.empForm.value);
    this.employeesService.addEmployee(this.empForm.value).subscribe({
      next: (employee) => {
        console.log("addEmployee",employee);
        // this.router.navigate(['employees']);
      },
      error: (err) => {
        console.log(err);
      }
    })

  }
}
