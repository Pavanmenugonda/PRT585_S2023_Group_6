import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeesService } from 'src/app/services/employees.service';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-emp-add-edit',
  templateUrl: './emp-add-edit.component.html',
  styleUrls: ['./emp-add-edit.component.css']
})

export class EmpAddEditComponent implements OnInit {
  empForm: FormGroup;
  
 

  constructor(
    private employeesService: EmployeesService,
    private router: Router,
    private _formBuilder: FormBuilder,
    private _diaglogRef: MatDialogRef<EmpAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    ) { 
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

  ngOnInit(): void {
    // patch the data to the form
    this.empForm.patchValue(this.data);
  }

  onFormSubmit() {
    // console.log(this.empForm.value);
    if(this.empForm.valid) {
      // console.log('empForm',this.empForm.value);
      if(this.data) {
        this.updateEmployee();
        this._diaglogRef.close(true);
      }else{
        this.addEmployee();
        this._diaglogRef.close(true);
      }
     
    }else {
      console.log('empForm',this.empForm.value);
      alert('Please fill all the required fields to create a super hero!');
    }
  }

  addEmployee(): void {
    console.log('empForm',this.empForm.value);
    this.employeesService.addEmployee(this.empForm.value).subscribe({
      next: (employee) => {
        console.log("addEmployee",employee);
        // this.router.navigate(['employees']);
        alert('Employee added successfully!');
      },
      error: (err) => {
        console.log(err);
      }
    })

  }

  updateEmployee(): void {
    console.log('updateEmpForm',this.empForm.value);
    this.employeesService.updateEmployee(this.data.id, this.empForm.value).subscribe({
      next: (employee) => {
        console.log("UpdateEmployee",employee);
        // this.router.navigate(['employees']);
        alert('Employee updated successfully!');
      },
      error: (err) => {
        console.log(err);
      }
    })

  }
}
