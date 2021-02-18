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
}
