import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Quizz } from '../_models/quizz';

@Injectable({
  providedIn: 'root'
})
export class QuizzService {

  userJson = sessionStorage['user'];
  user = JSON.parse(this.userJson);

  constructor() { }

  getUserQuizz(id: number) : Promise<Quizz[]>{
    return fetch(`${environment.apiUrl}/UserQuizzes/${id}`).then(resp => resp.json());
  }
}
