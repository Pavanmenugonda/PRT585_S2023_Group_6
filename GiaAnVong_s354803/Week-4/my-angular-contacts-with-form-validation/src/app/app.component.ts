
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

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
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
  // dataSource!: MatTableDataSource<any>;

  // @ViewChild(MatPaginator) paginator!: MatPaginator;
  // @ViewChild(MatSort) sort!: MatSort;

  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;

  constructor (private _dialog: MatDialog, private employeesService: EmployeesService) {}
  
  ngOnInit(): void {
    this.getEmployeesList();
  }
  
 
  openAddEditEmpForm() {
    this._dialog.open(EmpAddEditComponent, {
      width: '60%',
      height: '80%'
    });
  }

  getEmployeesList() {
    this.employeesService.getAllemployees().subscribe({
      next: (employees) => {
        console.log(employees);
        this.employees = employees;
        // this.dataSource = new MatTableDataSource(employees);
        // this.sort = this.sort;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
