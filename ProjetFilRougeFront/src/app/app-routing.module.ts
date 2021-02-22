import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CategoriesComponent } from './_pages/categories/categories.component';
import { CategoryFormComponent } from './_pages/category-form/category-form.component';
import { GeneratesQuizzesComponent } from './_pages/generates-quizzes/generates-quizzes.component';

const routes: Routes = [
  {path: "categories", component: CategoriesComponent, children: [
    {path: "ajouter", component: CategoryFormComponent}
  ]},
  {path: "gestionQuizz/:id", component: GeneratesQuizzesComponent},
  //{path: "niveaux", },
  //{path: "recruteurs", },
  //{path: "candidats", },
  //{path: "questions", },

  {path: "**", redirectTo: ""}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
