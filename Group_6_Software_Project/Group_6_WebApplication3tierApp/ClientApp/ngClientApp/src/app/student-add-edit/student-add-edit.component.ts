import { Component, ViewEncapsulation } from "@angular/core";
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from "@angular/forms";
import { StudentsService } from "../services/students.service";

@Component({
  selector: 'app-student-add-edit',
  templateUrl: './student-add-edit.component.html',
  styleUrls: ['./student-add-edit.component.less'],
  encapsulation: ViewEncapsulation.None,
})

export class StudentAddEditComponent {
  form: FormGroup;

  public value = '';

  public data: any = {
    StudentID: 0,
    StudentName: "",

  };

  constructor(private formBuilder: FormBuilder, private studentsService: StudentsService) { 
    // create form
    this.form = this.formBuilder.group({
      StudentName: new FormControl(this.data.StudentName, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ]),
    });
    
  }

  ngOnInit(): void {
    this.form.patchValue(this.data);
    console.log(this.data);
  }

  public submitForm(): void {
    this.form.markAllAsTouched();
    if (this.form.valid) {
      console.log("Form Submitted!");
      console.log(this.form.value);
      // console.log(this.data);
      // this.data = []
       this.addStudent();
      this.form.reset();
    }
  }
  public clearForm(): void {
    this.form.reset();
  }

  addStudent(): void {
    console.log('empForm',this.form.value);
    this.studentsService.addStudent(this.form.value).subscribe({
      next: (student: any) => {
        console.log("addstudent",student);
        // this.router.navigate(['employees']);
        
        // this.coreService.openSnackBar('Employee added successfully!', 'OK')
      },
      error: (err) => {
        console.log(err);
      }
    })

  }
}
