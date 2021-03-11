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
import { PassageQuizComponent } from './_pages/passage-quiz/passage-quiz.component';
import { DetailsQuizzComponent } from './_pages/details-quizz/details-quizz.component';
import { DetailsQuizzFormComponent } from './_components/details-quizz-form/details-quizz-form.component';
import { LevelsComponent } from './_pages/levels/levels.component';
import { LevelFormComponent } from './_pages/level-form/level-form.component';
import { QuizzResultComponent } from './_pages/quizz-result/quizz-result.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { SendsQuizzComponent } from './_pages/sends-quizz/sends-quizz.component';
import { SendsQuizzFormComponent } from './_components/sends-quizz-form/sends-quizz-form.component';
import { GeneratePdfComponent } from './_components/generate-pdf/generate-pdf.component';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import { jsPDF } from "jspdf";
import { RecruteursComponent } from './_pages/recruteurs/recruteurs.component';
import { RecruteurFormComponent } from './_pages/recruteur-form/recruteur-form.component';
import { DemandeAdhesionComponent } from './_components/demande-adhesion/demande-adhesion.component';
import { AcceuilComponent } from './_pages/acceuil/acceuil.component';
pdfMake.vfs = pdfFonts.pdfMake.vfs;

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
    PassageQuizComponent,
    DetailsQuizzComponent,
    DetailsQuizzFormComponent,
    LevelsComponent,
    LevelFormComponent,
    QuizzResultComponent,
    SendsQuizzComponent,
    SendsQuizzFormComponent,
    GeneratePdfComponent,
    RecruteursComponent,
    RecruteurFormComponent,
    DemandeAdhesionComponent,
    AcceuilComponent,
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
    GoogleChartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
