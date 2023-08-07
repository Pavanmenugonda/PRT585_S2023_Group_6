import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl , FormGroupDirective} from '@angular/forms';
import { EmployeesService } from 'src/app/services/employees.service';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { OnInit } from '@angular/core';
import { CoreService } from '../core/core.service';
import {ErrorStateMatcher} from '@angular/material/core';

import {
  NgForm,
  
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-emp-add-edit',
  templateUrl: './emp-add-edit.component.html',
  styleUrls: ['./emp-add-edit.component.css']
})



export class EmpAddEditComponent implements OnInit {
  empForm: FormGroup;
  
  matcher = new MyErrorStateMatcher();

  constructor(
    private employeesService: EmployeesService,
    private router: Router,
    private _formBuilder: FormBuilder,
    private _diaglogRef: MatDialogRef<EmpAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private coreService: CoreService,
    ) { 
      this.empForm = this._formBuilder.group({
        name:['', [Validators.required]],
        dateOfBirth:['', [Validators.required, this.dateFormatValidator]], // Adding date validation
        gender:['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]], // Adding email validation
        phone:'',
        salary:'',
        department:'',
      }, { varidators: this.dateFormatValidator})
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
      this.coreService.openSnackBar('Please fill all the required fields to create an employee!', 'OK')
    }
  }

  addEmployee(): void {
    console.log('empForm',this.empForm.value);
    this.employeesService.addEmployee(this.empForm.value).subscribe({
      next: (employee) => {
        console.log("addEmployee",employee);
        // this.router.navigate(['employees']);
        
        this.coreService.openSnackBar('Employee added successfully!', 'OK')
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
        this.coreService.openSnackBar('Employee updated successfully!', 'OK')
      },
      error: (err) => {
        console.log(err);
      }
    })

  }

  // Custom validator for date format (DD/MM/YYYY)
  dateFormatValidator(control: any) {
    const regex = /^(0?[1-9]|[12][0-9]|3[01])\/(0?[1-9]|1[0-2])\/\d{4}$/;
    const inputValue = control.value;
  
    // Parse the input value as a Date
    const inputDate = new Date(inputValue);
  
    // Check if the parsed date is valid and format it as "d/m/yyyy"
    const formattedDate = inputDate.getDate() + '/' + (inputDate.getMonth() + 1) + '/' + inputDate.getFullYear();
  
    console.log('Formatted date:', formattedDate);
  
    return regex.test(formattedDate) ? null : { dateFormat: true };
  }
  
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    const isError = !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
    if (isError==true){

      console.log('MyErrorStateMatcher - i}sError:', isError, control);
    }

    return isError;
  }
}
