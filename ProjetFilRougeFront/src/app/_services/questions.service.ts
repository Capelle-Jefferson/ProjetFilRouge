import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Question } from '../_models/question';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

  constructor() {}

  getAll():Promise<Question[]> {
    return fetch(`${environment.apiUrl}/Questions`).then(response => response.json());
  }
  
  create(question :any):Promise<Question>{
      console.log(question)
      return fetch(`${environment.apiUrl}/Questions`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(question)
      })
      .then(resp => resp.json());
  }

  delete(id : number): Promise<number>{
      console.log(`${environment.apiUrl}/Questions/${id}`);
      return fetch(`${environment.apiUrl}/Questions/${id}`, {
        method: 'DELETE'
      })
      .then(resp => resp.json());
  }

  // get(id : number): Promise<Question>{
  //   return fetch(`${environment.apiUrl}/Questions/${id}`).then(resp => resp.json());
  // }

  // getByIds(idLevel:number,idCategory:number,nombreQuestion:number) : Promise<Question> {
  //   return fetch(`${environment.apiUrl}/Questions/${idLevel}/${idCategory}/${nombreQuestion}`).then(resp=>resp.json());
  // }
  
}
