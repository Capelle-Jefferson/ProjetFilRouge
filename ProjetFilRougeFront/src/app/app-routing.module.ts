import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  //{path: "categories", },
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
