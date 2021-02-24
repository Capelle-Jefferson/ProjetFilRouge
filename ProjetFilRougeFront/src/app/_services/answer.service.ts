import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Answers } from '../_models/Answers';

@Injectable({
  providedIn: 'root'
})
export class AnswerService {

  constructor() { }

  create(answer :any):Promise<Answers>{
    return fetch(`${environment.apiUrl}/Answer`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(answer)
    })
    .then(resp => resp.json());
}
}
