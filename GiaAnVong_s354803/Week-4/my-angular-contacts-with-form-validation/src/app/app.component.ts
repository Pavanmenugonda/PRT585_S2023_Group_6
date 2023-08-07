
import { MatDialog } from '@angular/material/dialog';
import { EmpAddEditComponent } from './emp-add-edit/emp-add-edit.component';
import { EmployeesService } from './services/employees.service';
import { Employee } from './models/employee.model';
import { OnInit } from '@angular/core';
import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

// export interface PeriodicElement {
//   name: string;
//   position: number;
//   weight: number;
//   symbol: string;
// }
const ELEMENT_DATA: Employee[] = [
  {id: "345934859843", name: 'Test', dateOfBirth: "2023-08-03T14:30:00", gender: 'male', email: 'aa@aa.cc', phone: '2323', salary: 110, department: 'SDX'},
  {id: "123123123123", name: 'Test', dateOfBirth: "2023-08-03T14:30:00", gender: 'male', email: 'aa@aa.cc', phone: '2323', salary: 110, department: 'SDX'},
];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})

export class AppComponent implements OnInit {
  title = 'Employee Management System';
  employees: Employee[] = [];

  // displayedColumns: string[] = ['id',
  //   'name',
  //   'dateOfBirth',
  //   'gender',
  //   'email',
  //   'phone',
  //   'salary',
  //   'department',
  // ];
  dataSource!: MatTableDataSource<Employee>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  // displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  displayedColumns: string[] = [
    'id',
    'name',
    'dateOfBirth',
    'gender',
    'email',
    'phone',
    'salary',
    'department',
    'action',
  ];
  // dataSource = ELEMENT_DATA;

  constructor (private _dialog: MatDialog, private employeesService: EmployeesService) {}
  
  ngOnInit(): void {
    this.getEmployeesList();
    // console.log("dataSource", this.dataSource);
  }
  
 
  openAddEditEmpForm() {
    const dialogRef = this._dialog.open(EmpAddEditComponent, {
      width: '60%',
      height: '80%'
    });
    dialogRef.afterClosed().subscribe({
      next: (result) => {
        console.log(result);
        if(result) {
          this.getEmployeesList();
        }
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  getEmployeesList() {
    this.employeesService.getAllemployees().subscribe({
      next: (employees) => {
        console.log('employees',employees);
        // this.employees = employees;
        this.dataSource = new MatTableDataSource(employees);
        this.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  DeleteEmployeeInfo(id: string) {
    this.employeesService.DeleteEmployee(id).subscribe({
      next: (employee) => {
        console.log(employee);
        alert("Employee deleted successfully!");
        this.getEmployeesList();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  openEditEmpForm(data: any) {
    const dialogRef = this._dialog.open(EmpAddEditComponent, {
      data: data,
      width: '60%',
      height: '80%'
    });
    dialogRef.afterClosed().subscribe({
      next: (result) => {
        console.log(result);
        if(result) {
          this.getEmployeesList();
        }
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
