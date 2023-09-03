import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonComponent } from './components/person/person.component';
import { StudentComponent } from './components/student/student.component';
import { StudentAddEditComponent } from './student-add-edit/student-add-edit.component';
const routes: Routes = [
  { path: 'person', component: PersonComponent },
  { path: 'student', component: StudentComponent },
  { path: 'student/add', component: StudentAddEditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
