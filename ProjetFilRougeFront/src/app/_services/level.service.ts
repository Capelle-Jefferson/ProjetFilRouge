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
}
