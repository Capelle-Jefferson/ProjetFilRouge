import { Component, Input, OnInit } from '@angular/core';
import { Question } from 'src/app/_models/question';
import { QuizzService } from 'src/app/_services/quizz.service';

@Component({
  selector: 'app-passage-quiz',
  templateUrl: './passage-quiz.component.html',
  styleUrls: ['./passage-quiz.component.css']
})
export class PassageQuizComponent implements OnInit {

  @Input() question : Question;
  istypeAnswer:boolean;


  constructor(private service:QuizzService) { }

  ngOnInit(): void {
    this.istypeAnswer = this.question.answer.typeAnswer != 'Text'
  }

  addCandidateAnswer(){}

}
