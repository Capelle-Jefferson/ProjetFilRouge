import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  getAuthentification(user: User): Promise<User>{
    return fetch('https://localhost:5001/api/authentification', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
     })
      .then(response => response.json())
  }

  getAll(): Promise<User[]>{
    return fetch("https://localhost:5001/api/user").then(resp => resp.json());
  }
}
