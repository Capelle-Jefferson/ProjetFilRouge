import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sends-quizz',
  templateUrl: './sends-quizz.component.html',
  styleUrls: ['./sends-quizz.component.css']
})
export class SendsQuizzComponent implements OnInit {

  private sub: any;
  codeQuizz;

  candJson = localStorage['candidate'];
  candidate = JSON.parse(this.candJson);

  constructor(
    private route: ActivatedRoute
  ) {
   }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.codeQuizz = params['codeQuizz'];
    })

  }

}
