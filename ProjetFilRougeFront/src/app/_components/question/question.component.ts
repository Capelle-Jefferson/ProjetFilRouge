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
  istypeAnswer:boolean;


  constructor(private serviceQ:QuestionsService,private serviceA:AnswerService,private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.istypeAnswer = this.question.answer.typeAnswer != 'text'
  }

  async deleteQuestion(question : Question){
    let res;
    await this.serviceQ.delete(question.idQuestion).then(data => res = data);
    if(res == 1) {
       this.toastr.success("La question a bien était supprimée");
       this.router.navigateByUrl("/QuestionComponent", { skipLocationChange: true}).then(() => {
        this.router.navigate(["/questions"]);
      })
    }
    else {
        this.toastr.error("La question appartient à un quizz, elle ne peut pas être supprimée")
    }

  }

}
