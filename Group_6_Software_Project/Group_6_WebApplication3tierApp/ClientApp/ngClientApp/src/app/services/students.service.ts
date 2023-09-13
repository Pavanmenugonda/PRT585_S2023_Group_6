import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private http: HttpClient) { }
  baseUrl: string = environment.baseUrl;

  getAllStudents(): Observable<Student[]>{
    return this.http.get<Student[]>(this.baseUrl + '/api/Student')
  }

  addStudent(addStudentRequest: Student): Observable<Student> {
    
    return this.http.post<Student>(this.baseUrl + '/api/Student', addStudentRequest);

  }

  getStudent(id: string): Observable<Student> {
    
    return this.http.get<Student>(this.baseUrl + '/api/Student/' + id);

  }

  updateStudent(id: string, editStudentRequest: Student): Observable<Student> {
    
    return this.http.put<Student>(this.baseUrl + '/api/Student/' + id, editStudentRequest);

  }
  
  deleteStudent(id: string): Observable<Student> {
    
    return this.http.delete<Student>(this.baseUrl + '/api/Student/' + id);

  }
}
