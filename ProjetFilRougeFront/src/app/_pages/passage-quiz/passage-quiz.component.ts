import { Component, Input, OnInit } from '@angular/core';
import { Answers } from 'src/app/_models/Answers';
import { Question } from 'src/app/_models/question';
import { Quizz } from 'src/app/_models/quizz';
import { QuizzQuestionService } from 'src/app/_services/quizz-question.service';
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
  isQcmUnique:boolean;
  Next :boolean = false;
  question:any;
  nombre:number=0;
  isFinished:boolean=false;
  answerCandidate:string;
  lastPage:boolean=false;
  

  constructor(private service:QuizzQuestionService) { }

  ngOnInit(): void {
    this.suppresionLocalQuizz();
  }

  onSubmit(){
    this.service.addCandidateAnswer(this.quizz.idQuizz,this.question.idQuestion,this.answerCandidate);
    this.nombre=this.nombre+1;
    this.question=this.quizz.questions[this.nombre];
    this.Next=true;
    this.istypeAnswer=this.question.answer.typeanswer!="Text";
    if(this.nombre===this.quizz.questions.length-1){
      this.isFinished=true;
    }
  }

  SaveAnswer(value:string){
    this.answerCandidate=value;
  }
  SaveAnswerText=()=>{
    this.answerCandidate=(<HTMLInputElement>document.getElementById("reponse")).value;
  }
  goToFirstQuestion(){
    this.question=this.quizz.questions[this.nombre];
    this.Next=true;
    this.istypeAnswer=this.question.answer.typeAnswer!="Text";
    this.isQcmUnique=this.question.answer.typeAnswer!="qcm_multiple";
  }
  FinduQuizz(){
    this.service.addCandidateAnswer(this.quizz.idQuizz,this.question.idQuestion,this.answerCandidate);
    this.Next=false;
    this.isFinished=false;
    this.lastPage=true;
    

  }
  // Suppresion de la variable local Quizz unt fois le quizz completé
  suppresionLocalQuizz(){
    localStorage.removeItem("quizz");
  }
  
}
