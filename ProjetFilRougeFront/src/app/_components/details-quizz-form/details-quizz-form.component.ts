import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
    private service: QuizzQuestionService,
    private router : Router,
    private toastr : ToastrService
  ) { 
    this.answerForm = this.builder.group({
      isCorrectAnswer: [null, [Validators.required]]
    })
  }

  ngOnInit(): void {
  }

  async onSubmit() {
    await this.service.correctCandidateAnswer(
      this.idQuizz,
      this.question.idQuestion,
      +this.answerForm.get("isCorrectAnswer").value)

    this.router.navigateByUrl('/DetailsQuizzFormComponent', { skipLocationChange: true}).then(() => {
      this.router.navigate([`/gestionQuizz/details/${this.idQuizz}`]);
    this.toastr.success("La correction à bien était appliqué");
    })
  }
}
