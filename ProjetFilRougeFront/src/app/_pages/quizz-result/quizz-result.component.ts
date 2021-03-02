import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuizzResult } from 'src/app/_models/QuizzResult';
import { QuizzService } from 'src/app/_services/quizz.service';

@Component({
  selector: 'app-quizz-result',
  templateUrl: './quizz-result.component.html',
  styleUrls: ['./quizz-result.component.css']
})
export class QuizzResultComponent implements OnInit {

  private sub: any;
  idQuizz : number;
  results : QuizzResult;

  // Charts
  type="PieChart";
  data : any;
  columnNames = ['Niveau', 'Pourcentage'];
  options = {
    
  }
  width = 1000;
  height = 600;


  constructor(
    private service : QuizzService,
    private route : ActivatedRoute
  ) { }

  async ngOnInit(){
    this.sub = this.route.params.subscribe(params => {
      this.idQuizz = +params['idQuizz'];
    })

    await this.service.getQuizzResult(this.idQuizz).then(data => this.results = data);

    let juniorP = this.results.resultJunior < 0 ? 0 : this.results.resultJuniorTotal * (this.results.resultJunior / 100)
    let confirmeP = this.results.resultConfirme < 0 ? 0 : this.results.resultConfirmeTotal * (this.results.resultConfirme / 100)
    let expertP = this.results.resultExpert < 0 ? 0 : this.results.resultExpertTotal * (this.results.resultExpert / 100)
    let restes = 100 - juniorP - confirmeP -expertP ;

    this.data = [
      ["Bonnes réponses, difficulté junior", juniorP],

      ["Bonnes réponses, difficulté confirmé", confirmeP],

      ["Bonnes réponses, difficulté expert", expertP],

      ["Mauvaises réponses", restes],
    ]

    console.log(this.results)
  }

}
