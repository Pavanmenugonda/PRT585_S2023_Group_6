import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PersonComponent } from './components/person/person.component';
import { StudentComponent } from './components/student/student.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { FormsModule } from "@angular/forms";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { InputsModule } from "@progress/kendo-angular-inputs";


@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    StudentComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    GridModule,
    FormsModule,
    ButtonsModule,
    InputsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
