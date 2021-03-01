import { Component, Input, OnInit } from '@angular/core';
import { Question } from 'src/app/_models/question';
import { Quizz } from 'src/app/_models/quizz';
import { QuizzService } from 'src/app/_services/quizz.service';
import { QuestionsComponent } from '../questions/questions.component';

@Component({
  selector: 'app-passage-quiz',
  templateUrl: './passage-quiz.component.html',
  styleUrls: ['./passage-quiz.component.css']
})
export class PassageQuizComponent implements OnInit {

  @Input() quizz;
  istypeAnswer:boolean;
  Next :boolean = false;
  question:any;
  nombre:number=0;
  isFinished:boolean=false;
  


  constructor(private service:QuizzService) { }

  ngOnInit(): void {
    this.quizz.questions.forEach(question=>{
      this.istypeAnswer=question.answer.typeanswer!="Text";
    })
  }

  addCandidateAnswer(){}
  onSubmit(){
    console.log("Ok");
    let nombre2=this.nombre+1;
    this.question=this.quizz.questions[nombre2];
    this.Next=true;
    if(nombre2===this.quizz.questions.length-1){
      this.isFinished=true;
    }
    //document.location.reload();
  }
  goToFirstQuestion(){
    this.question=this.quizz.questions[this.nombre];
    this.Next=true;
  }
  FinduQuizz(){
    this.suppresionLocalQuizz();
  }
  // Suppresion de la variable local Quizz unt fois le quizz completé
  suppresionLocalQuizz(){
    localStorage.removeItem("quizz");
  }
}
