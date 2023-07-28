import { Component } from '@angular/core';
import {FormComponent} from './form/form.component'
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { from } from 'rxjs';
import { StudentsComponent } from './students/students.component';

const routes: Routes = [
  { path: 'registration', component: FormComponent},
  { path: 'student-list', component: StudentsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
