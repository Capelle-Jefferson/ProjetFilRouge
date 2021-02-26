import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-connexion-quizz',
  templateUrl: './connexion-quizz.component.html',
  styleUrls: ['./connexion-quizz.component.css']
})
export class ConnexionQuizzComponent implements OnInit {

  quizzJson = localStorage.getItem("quizz");
  quizz = JSON.parse(this.quizzJson);
  isQuizz = this.quizz != null;

  constructor(
  ) { }

  ngOnInit(): void {
    console.log(this.quizz)

    // Suppresion de la variable local Quizz unt fois le quizz completé
    this.suppresionLocalQuizz();
  }

  suppresionLocalQuizz(){
    localStorage.removeItem("quizz");
  }

}
