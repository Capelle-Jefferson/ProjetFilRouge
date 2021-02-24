import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Question } from 'src/app/_models/question';
import { AnswerService } from 'src/app/_services/answer.service';
import { QuestionsService } from 'src/app/_services/questions.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  @Input() question : Question;
  constructor(private serviceQ:QuestionsService,private serviceA:AnswerService,private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  deleteQuestion(question : Question){
    let res : Number;
    this.serviceQ.delete(question.id).then(data => res = data );
    this.router.navigateByUrl("question", { skipLocationChange: true}).then(() => {
      this.router.navigate(["/Questions"]);
    this.toastr.success("La question a bien était supprimée");
    })
  }

}
