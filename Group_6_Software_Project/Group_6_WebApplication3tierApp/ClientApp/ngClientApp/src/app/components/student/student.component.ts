import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { StudentsService } from 'src/app/services/students.service';
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.less']
})
export class StudentComponent implements OnInit {

  students: Student[] = [];

  constructor(private studentsService: StudentsService) { }

  ngOnInit(): void {
    this.studentsService.getAllStudents().subscribe({
      next: (students: Student[] ) => {
        // push students to this.students
        this.students = students;
        // console.log('students',this.students);
        students.forEach((student) => {
          console.log(student.StudentId);
        });
      },
      error: (err) => {
        console.log(err);
      }
    });
    
  }

}
