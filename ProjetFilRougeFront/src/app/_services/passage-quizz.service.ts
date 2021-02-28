import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Question } from '../_models/question';

@Injectable({
  providedIn: 'root'
})
export class PassageQuizzService {

  constructor() { }

  // getQuestions():Promise<Question[]> {
  //   return fetch(`${environment.apiUrl}/QuizzesInProgress`).then(response => response.json());
  // }
}
