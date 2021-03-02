import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Quizz } from '../_models/quizz';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class QuizzService {

  userJson = sessionStorage['user'];
  user : User;

  constructor() { 
    if(this.userJson != undefined){
      this.user = JSON.parse(this.userJson);
    }
  }

  get(id: number) : Promise<Quizz>{
    return fetch(`${environment.apiUrl}/Quizzes/${id}`).then(resp => resp.json());
  }

  getUserQuizz(id: number) : Promise<Quizz[]>{
    return fetch(`${environment.apiUrl}/UserQuizzes/${id}`).then(resp => resp.json());
  }

  getQuizzByCode(code : string): Promise<Quizz>{
    return fetch(`${environment.apiUrl}/QuizzesInProgress/${code}`).then(resp => resp.json());
  }

  create(quizz, nbQuestions : number): Promise<Quizz>{
    return fetch(`${environment.apiUrl}/Quizzes/${nbQuestions}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(quizz)
    })
    .then(resp => resp.json());
  }

  delete(id : number): Promise<number>{
    console.log(`${environment.apiUrl}/quizzes/${id}`);
    return fetch(`${environment.apiUrl}/quizzes/${id}`, {
      method: 'DELETE'
    })
    .then(resp => resp.json());
  }

  correctQuiz(id:number){
     fetch(`${environment.apiUrl}/Correctquizz/${id}` ,{
      method:'PUT'});
  }
}
