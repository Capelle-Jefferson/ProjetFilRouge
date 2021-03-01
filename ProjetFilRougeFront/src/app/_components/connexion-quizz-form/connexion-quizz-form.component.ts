import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MinLengthValidator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Quizz } from 'src/app/_models/quizz';
import { QuizzService } from 'src/app/_services/quizz.service';

@Component({
  selector: 'app-connexion-quizz-form',
  templateUrl: './connexion-quizz-form.component.html',
  styleUrls: ['./connexion-quizz-form.component.css']
})
export class ConnexionQuizzFormComponent implements OnInit {

  codeQuizzForm : FormGroup
  quizz : Quizz
  msgErreur : string

  constructor(
    private builder : FormBuilder,
    private service : QuizzService,
    private router : Router
  ) { 
    this.codeQuizzForm = this.builder.group({
      codeQuizz: ["", Validators.required]
    })
  }

  ngOnInit(): void {
  }

  async onSubmit(){
    try{
      await this.service.getQuizzByCode(this.codeQuizzForm.get("codeQuizz").value)
      .then(data => this.quizz = data);
    }catch{
      this.msgErreur = "Le code est incorrecte !";
    }


    if(this.quizz["idQuizz"]){
      localStorage.setItem("quizz", JSON.stringify(this.quizz));
      location.reload();
    }else{
      this.msgErreur = "Le code est incorrecte !";
    }
  }

}
