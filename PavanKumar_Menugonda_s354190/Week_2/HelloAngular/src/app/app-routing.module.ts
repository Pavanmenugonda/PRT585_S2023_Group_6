import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component'; // Import the AboutUsComponent

const routes: Routes = [
  // Other routes if you have them
  { path: 'about-us', component: AboutUsComponent },

  // Other routes if you have them
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
