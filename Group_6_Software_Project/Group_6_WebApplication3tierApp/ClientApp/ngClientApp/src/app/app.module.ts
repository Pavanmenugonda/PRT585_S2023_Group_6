import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PersonComponent } from './components/person/person.component';
import { StudentComponent } from './components/student/student.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { InputsModule, TextBoxModule } from "@progress/kendo-angular-inputs";
import { StudentAddEditComponent } from './student-add-edit/student-add-edit.component';
import { LabelModule } from '@progress/kendo-angular-label';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    StudentComponent,
    StudentAddEditComponent
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
    TextBoxModule,
    LabelModule,
    ReactiveFormsModule,
    LayoutModule,
    DropDownsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
