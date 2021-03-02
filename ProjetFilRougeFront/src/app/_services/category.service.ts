import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor() { }

  getAll(): Promise<Category[]>{
    return fetch(`${environment.apiUrl}/categories`).then(resp => resp.json());
  }

  create(category : Category): Promise<Category>{
    return fetch(`${environment.apiUrl}/categories`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(category)
    })
    .then(resp => resp.json());
  }

  delete(id : number): Promise<number>{
    return fetch(`${environment.apiUrl}/categories/${id}`, {
      method: 'DELETE'
    })
    .then(resp => resp.json());
  }
}
