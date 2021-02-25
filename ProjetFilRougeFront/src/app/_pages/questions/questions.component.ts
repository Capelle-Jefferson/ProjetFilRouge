import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/_models/question';
import { QuestionsService } from 'src/app/_services/questions.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  questions : Question[] =[];
  constructor(private questionService:QuestionsService) { }

  ngOnInit(): void {
      this.questionService.getAll().then(data => {
        this.questions = data;
      })
  }

}
