import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-details-quizz-form',
  templateUrl: './details-quizz-form.component.html',
  styleUrls: ['./details-quizz-form.component.css']
})
export class DetailsQuizzFormComponent implements OnInit {

  @Input() question;
  answerForm : FormGroup

  constructor(private builder : FormBuilder) { 
    this.answerForm = this.builder.group({
      isCorrectAnswer: [Boolean]
    })
  }

  ngOnInit(): void {
  }

  onSubmit() {
    console.log(this.answerForm.value)
  }

}
