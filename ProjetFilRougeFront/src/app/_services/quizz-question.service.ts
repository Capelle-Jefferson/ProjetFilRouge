import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { QuizzQuestion } from '../_models/quizzQuestion';

@Injectable({
  providedIn: 'root'
})
export class QuizzQuestionService {

  constructor() { }

  correctCandidateAnswer(idQuizz:number, idQuestion:number, isCorrectAnswer : number): Promise<QuizzQuestion>{
    return fetch(`${environment.apiUrl}/quizzQuestionCorrectAnswer?idQuizz=${idQuizz}&idQuestion=${idQuestion}&answer=${isCorrectAnswer}`, {
      method: 'put'
    })
    .then(resp => resp.json());
  }
  addCandidateAnswer(idQuizz:number, idQuestion:number, candidateAnswer:string): Promise<QuizzQuestion>{
    return fetch(`${environment.apiUrl}/quizzQuestion?idQuizz=${idQuizz}&idQuestion=${idQuestion}`, {
      method: 'put',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(candidateAnswer)
    })
    .then(resp => resp.json());
  }

}