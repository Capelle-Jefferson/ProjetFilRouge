import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Level } from '../_models/level';

@Injectable({
  providedIn: 'root'
})
export class LevelService {

  constructor() { }

  getAll(): Promise<Level[]>{
    return fetch(`${environment.apiUrl}/levels`).then(resp => resp.json());
  }

  create(level : Level): Promise<Level>{
    return fetch(`${environment.apiUrl}/levels`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(level)
    })
    .then(resp => resp.json());
  }

  delete(id : number): Promise<number>{
    console.log(`${environment.apiUrl}/levels/${id}`);
    return fetch(`${environment.apiUrl}/levels/${id}`, {
      method: 'DELETE'
    })
    .then(resp => resp.json());
  }
}
