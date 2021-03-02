import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Quizz } from 'src/app/_models/quizz';
import { QuizzService } from 'src/app/_services/quizz.service';

@Component({
  selector: 'app-details-quizz',
  templateUrl: './details-quizz.component.html',
  styleUrls: ['./details-quizz.component.css']
})
export class DetailsQuizzComponent implements OnInit {

  idCandidate : number;
  idQuizz : number;
  private sub: any;
  quizz;

  constructor(
    private route: ActivatedRoute,
    private serviceQuizz : QuizzService
  ) { }

  async ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.idQuizz = +params['idQuizz'];
    })
    await this.serviceQuizz.get(this.idQuizz).then(data => this.quizz = data);

    this.idCandidate = +localStorage.getItem("idCandidate");
    localStorage.removeItem("idCandidate");
  }

  public isQuizzCompleted() : boolean{
    for(let question of this.quizz.questions){
      if(question.isCorrectAnswer == null){
        return true
      }
    }
    return false;
  }

}
