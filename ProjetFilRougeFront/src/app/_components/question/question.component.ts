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
  deleteIcon = "../assets/images/icons/trash.svg";


  constructor(private serviceQ:QuestionsService,private serviceA:AnswerService,private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  deleteQuestion(question : Question){
    try {
       this.serviceQ.delete(question.idQuestion);
       this.toastr.success("La question a bien était supprimée");
    }
    catch {
        this.toastr.warning("La question appartient à un quizz, elle ne peut pas être supprimée")
    }
    this.router.navigateByUrl("/QuestionComponent", { skipLocationChange: true}).then(() => {
    this.router.navigate(["/questions"]);
    })
  }

}
