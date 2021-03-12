import { Component, Input, OnInit } from '@angular/core';
import { CheckboxRequiredValidator } from '@angular/forms';
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
  istypeAnswer: boolean;
  isQcmUnique: boolean;
  Next: boolean = false;
  question: any;
  nombre: number = 0;
  isFinished: boolean = false;
  answerCandidate: string;
  lastPage: boolean = false;


  constructor(private service: QuizzQuestionService, private quizzService:QuizzService) { }

  ngOnInit(): void {
    this.suppresionLocalQuizz();
  }

  onSubmit() {
    this.service.addCandidateAnswer(this.quizz.idQuizz, this.question.idQuestion, this.answerCandidate);
    this.nombre = this.nombre + 1;
    this.question = this.quizz.questions[this.nombre];
    this.Next = true;
    this.istypeAnswer = (this.question.answer.typeAnswer != "Text");
    this.isQcmUnique = (this.question.answer.typeAnswer != "QCM_multiple");
    if (this.nombre === this.quizz.questions.length - 1) {
      this.isFinished = true;
    }
    console.log(this.istypeAnswer);
    console.log(this.question.answer.typeAnswer);
  }
  SaveAnswers = () => {
    this.answerCandidate="";
    var i,box;
    var boxes = document.getElementsByName("name");
    var checked=[]; 
    for (i=0; i < boxes.length; ++i) {
        box = boxes[i];
        if (box.name=="name" && box.checked) {
            checked.push(box.value);
        }
    }
    //Concatenation des valeurs des checkboxes
    this.answerCandidate=checked.join('§'); 
  }

  SaveAnswer(value: string) {
    this.answerCandidate = value;
    console.log(this.answerCandidate);
  }
  SaveAnswerText = () => {
    this.answerCandidate = (<HTMLInputElement>document.getElementById("reponse")).value;
  }
  goToFirstQuestion() {
    this.question = this.quizz.questions[this.nombre];
    this.Next = true;
    this.istypeAnswer = (this.question.answer.typeAnswer != "Text");
    this.isQcmUnique = (this.question.answer.typeAnswer != "QCM_multiple");
    console.log(this.question.answer.typeAnswer);
  }
  FinduQuizz() {
    this.service.addCandidateAnswer(this.quizz.idQuizz, this.question.idQuestion, this.answerCandidate);
    this.quizzService.correctQuiz(this.quizz.idQuizz);
    this.Next = false;
    this.isFinished = false;
    this.lastPage = true;
  }
  // Suppresion de la variable local Quizz une fois le quizz completé
  suppresionLocalQuizz() {
    localStorage.removeItem("quizz");
  }

}
