
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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

  // getById(id:number) : Observable<Question> {
  //   return this.http.get<Question>(`${environment.apiUrl}/Questions/${id}`);
  // }
  // getByIds(idLevel:number,idCategory:number,nombreQuestion:number) : Observable<Question> {
  //   return this.http.get<Question>(`${environment.apiUrl}/Questions/${idLevel}/${idCategory}/${nombreQuestion}`);
  // }
    
  // create(question :Question) : Promise<Question>{
  //   return fetch(`${environment.apiUrl}/Questions`).then(question=> question.pos);
  // }
  

  // delete(id:number) :Observable<Question>{
  //   return this.http.delete<Question>(`${environment.apiUrl}/Questions/${id}`);

  // }


}
