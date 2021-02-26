import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
    private service : QuizzService
  ) { 
    this.codeQuizzForm = this.builder.group({
      codeQuizz: ["", Validators.required]
    })
  }

  ngOnInit(): void {
  }

  async onSubmit(){
     await this.service.getQuizzByCode(this.codeQuizzForm.get("codeQuizz").value)
      .then(data => this.quizz = data);

    if(this.quizz["idQuizz"]){
      console.log(this.quizz)
    }else{
      this.msgErreur = "Le code est incorrecte !";
    }
  }
  
}
