import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormQuestionComponent } from './_components/form-question/form-question.component';
import { QuestionsComponent } from './_pages/questions/questions.component';

const routes: Routes = [
  {path:"questions", component : QuestionsComponent,
    children:[
      {path:"formQuestion", component: FormQuestionComponent}
    ]
  },
  {path:"**", redirectTo:""}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
