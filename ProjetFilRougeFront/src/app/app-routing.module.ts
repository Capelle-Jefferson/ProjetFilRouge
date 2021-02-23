import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { FormQuestionComponent } from './_components/form-question/form-question.component';
import { CategoriesComponent } from './_pages/categories/categories.component';
import { CategoryFormComponent } from './_pages/category-form/category-form.component';
import { GenerateQuizzFormComponent } from './_pages/generate-quizz-form/generate-quizz-form.component';
import { GeneratesQuizzesComponent } from './_pages/generates-quizzes/generates-quizzes.component';
import { QuestionsComponent } from './_pages/questions/questions.component';

const routes: Routes = [
  {path: "categories", component: CategoriesComponent, children: [
    {path: "ajouter", component: CategoryFormComponent}
  ]},
  {path: "gestionQuizz/:id", component: GeneratesQuizzesComponent, children: [
    {path: "ajouter", component: GenerateQuizzFormComponent}
  ]},
  {path:"questions",component:QuestionsComponent,children:[
    {path:"ajouter",component:FormQuestionComponent}
  ]},
  //{path: "niveaux", },
  //{path: "recruteurs", },
  //{path: "candidats", },
  

  {path: "**", redirectTo: ""}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
