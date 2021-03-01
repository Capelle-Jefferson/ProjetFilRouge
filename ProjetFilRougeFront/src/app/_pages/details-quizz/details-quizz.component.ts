import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Quizz } from 'src/app/_models/quizz';
import { QuizzService } from 'src/app/_services/quizz.service';

@Component({
  selector: 'app-details-quizz',
  templateUrl: './details-quizz.component.html',
  styleUrls: ['./details-quizz.component.css']
})
export class DetailsQuizzComponent implements OnInit {

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
    console.log(this.quizz)

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
