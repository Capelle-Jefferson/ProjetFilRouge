import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  getAuthentification(user: User): Promise<User>{
    return fetch(`${environment.apiUrl}/authentification`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
     })
      .then(response => response.json())
  }

  getAll(): Promise<User[]>{
    return fetch(`${environment.apiUrl}/user`).then(resp => resp.json());
  }
  getAllRecruteur(): Promise<User[]>{
    return fetch(`${environment.apiUrl}/Recruteurs`).then(resp => resp.json());
  }

  get(id : number): Promise<User>{
    return fetch(`${environment.apiUrl}/user/${id}`).then(resp => resp.json());
  }

  delete(id : number): Promise<number>{
    return fetch(`${environment.apiUrl}/User/${id}`, {
      method: 'DELETE'
    })
    .then(resp => resp.json());
  }

  create(user : any):Promise<User>{
    return fetch(`${environment.apiUrl}/Recruteur`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(user)
    })
    .then(resp => resp.json());
}
}
