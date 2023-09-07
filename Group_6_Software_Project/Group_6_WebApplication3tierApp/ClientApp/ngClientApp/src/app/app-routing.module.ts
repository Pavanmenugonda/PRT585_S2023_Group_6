import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonComponent } from './components/person/person.component';
import { StudentComponent } from './components/student/student.component';
import { StudentAddEditComponent } from './student-add-edit/student-add-edit.component';
import { MovieComponent } from './components/movie/movie.component';
const routes: Routes = [
  { path: 'person', component: PersonComponent },
  { path: 'student', component: StudentComponent },
  { path: 'student/add', component: StudentAddEditComponent },
  { path: 'movie', component: MovieComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
