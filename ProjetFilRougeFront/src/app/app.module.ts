import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { from } from 'rxjs';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormQuestionComponent } from './_components/form-question/form-question.component';
import { QuestionComponent } from './_components/question/question.component';
import { QuestionsComponent } from './_pages/questions/questions.component';

@NgModule({
  declarations: [
    AppComponent,
    FormQuestionComponent,
    QuestionComponent,
    QuestionsComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
