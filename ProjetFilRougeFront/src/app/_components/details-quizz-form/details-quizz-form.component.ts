import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { QuizzQuestion } from 'src/app/_models/quizzQuestion';
import { QuizzQuestionService } from 'src/app/_services/quizz-question.service';

@Component({
  selector: 'app-details-quizz-form',
  templateUrl: './details-quizz-form.component.html',
  styleUrls: ['./details-quizz-form.component.css']
})
export class DetailsQuizzFormComponent implements OnInit {

  @Input() question;
  @Input() idQuizz;
  answerForm : FormGroup

  constructor(
    private builder : FormBuilder,
    private service: QuizzQuestionService
  ) { 
    this.answerForm = this.builder.group({
      isCorrectAnswer: [0]
    })
  }

  ngOnInit(): void {
  }

  async onSubmit() {
    let quizzQuestion : QuizzQuestion;

    await this.service.correctCandidateAnswer(
      this.idQuizz,
      this.question.idQuestion,
      +this.answerForm.get("isCorrectAnswer").value)
    .then(data => quizzQuestion=data)

    console.log(quizzQuestion)
  }
}
