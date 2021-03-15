import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormQuestionComponent } from './_components/form-question/form-question.component';
import { CandidateFormComponent } from './_pages/candidate-form/candidate-form.component';
import { CandidatesComponent } from './_pages/candidates/candidates.component';
import { CategoriesComponent } from './_pages/categories/categories.component';
import { CategoryFormComponent } from './_pages/category-form/category-form.component';
import { ConnexionQuizzComponent } from './_pages/connexion-quizz/connexion-quizz.component';
import { DetailsQuizzComponent } from './_pages/details-quizz/details-quizz.component';
import { GenerateQuizzFormComponent } from './_pages/generate-quizz-form/generate-quizz-form.component';
import { GeneratesQuizzesComponent } from './_pages/generates-quizzes/generates-quizzes.component';
import { QuestionsComponent } from './_pages/questions/questions.component';
import { LevelFormComponent } from './_pages/level-form/level-form.component';
import { LevelsComponent } from './_pages/levels/levels.component';
import { QuizzResultComponent } from './_pages/quizz-result/quizz-result.component';
import { SendsQuizzComponent } from './_pages/sends-quizz/sends-quizz.component';
import { RecruteursComponent } from './_pages/recruteurs/recruteurs.component';
import { RecruteurFormComponent } from './_pages/recruteur-form/recruteur-form.component';
import { AcceuilComponent } from './_pages/acceuil/acceuil.component';

const routes: Routes = [
  {path: "categories", component: CategoriesComponent, children: [
    {path: "ajouter", component: CategoryFormComponent}
  ]},
  {path: "gestionQuizz/:id", component: GeneratesQuizzesComponent, children: [
    {path: "ajouter", component: GenerateQuizzFormComponent}
  ]},
  {path: "gestionQuizz/details/:idQuizz", component: DetailsQuizzComponent},
  {path: "gestionQuizz/resultat/:idQuizz", component: QuizzResultComponent},
  {path: "gestionQuizz/envoyer/:codeQuizz", component: SendsQuizzComponent},
  {path:"questions",component:QuestionsComponent,children:[
    {path:"ajouter",component:FormQuestionComponent}
  ]},
  {path: "candidats", component: CandidatesComponent, children:[
    {path:"ajouter", component: CandidateFormComponent}
  ]},
  {path: "quiz", component: ConnexionQuizzComponent},
  {path: "niveaux", component: LevelsComponent, children: [
    {path: "ajouter", component: LevelFormComponent}
  ]},
  {path: "recruteurs", component: RecruteursComponent, children: [
    {path: "ajouter", component: RecruteurFormComponent}
  ]},
  {path:"accueil", component:AcceuilComponent},
  {path: "**", redirectTo: "accueil"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
