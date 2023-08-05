import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Employee } from '../models/employee.model';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }
  baseUrl: string = environment.baseUrl;

  getAllemployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.baseUrl + '/api/employees')
  }

  addEmployee(addEmployeeRequest: Employee): Observable<Employee> {
    
    return this.http.post<Employee>(this.baseUrl + '/api/employees', addEmployeeRequest);

  }

  getEmployee(id: string): Observable<Employee> {
    
    return this.http.get<Employee>(this.baseUrl + '/api/employees/' + id);

  }

  updateEmployee(id: string, editEmployeeRequest: Employee): Observable<Employee> {
    
    return this.http.put<Employee>(this.baseUrl + '/api/employees/' + id, editEmployeeRequest);

  }
  
  DeleteEmployee(id: string): Observable<Employee> {
    
    return this.http.delete<Employee>(this.baseUrl + '/api/employees/' + id);

  }
}
