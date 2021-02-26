import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { from } from 'rxjs';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormQuestionComponent } from './_components/form-question/form-question.component';
import { QuestionComponent } from './_components/question/question.component';
import { QuestionsComponent } from './_pages/questions/questions.component';
import { NavbarComponent } from './_components/navbar/navbar.component';
import { HeaderComponent } from './_components/header/header.component';
import { AuthentificationComponent } from './_pages/authentification/authentification.component';
import { FormAuthentificationComponent } from './_components/form-authentification/form-authentification.component';
import { HttpClientModule } from '@angular/common/http';
import { CategoriesComponent } from './_pages/categories/categories.component';
import { CategoryFormComponent } from './_pages/category-form/category-form.component';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { GeneratesQuizzesComponent } from './_pages/generates-quizzes/generates-quizzes.component';
import { GenerateQuizzFormComponent } from './_pages/generate-quizz-form/generate-quizz-form.component';
import { CandidatesComponent } from './_pages/candidates/candidates.component';
import { CandidateFormComponent } from './_pages/candidate-form/candidate-form.component';
import { ConnexionQuizzComponent } from './_pages/connexion-quizz/connexion-quizz.component';
import { ConnexionQuizzFormComponent } from './_components/connexion-quizz-form/connexion-quizz-form.component';

@NgModule({
  declarations: [
    AppComponent,
    FormQuestionComponent,
    QuestionComponent,
    QuestionsComponent,
    NavbarComponent,
    HeaderComponent,
    AuthentificationComponent,
    FormAuthentificationComponent,
    CategoriesComponent,
    CategoryFormComponent,
    GeneratesQuizzesComponent,
    GenerateQuizzFormComponent,
    CandidatesComponent,
    CandidateFormComponent,
    ConnexionQuizzComponent,
    ConnexionQuizzFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
