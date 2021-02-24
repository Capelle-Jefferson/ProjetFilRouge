import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Candidate } from '../_models/candidate';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor() { }

  getAll():Promise<Candidate[]> {
    return fetch(`${environment.apiUrl}/Candidate`).then(response => response.json());
  }

  get(id: number) : Promise<Candidate>{
    return fetch(`${environment.apiUrl}/Candidate/${id}`).then(resp => resp.json());
  }

  create(candidat :Candidate):Promise<Candidate>{
      return fetch(`${environment.apiUrl}/Candidate`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(candidat)
      })
      .then(resp => resp.json());
  }

  delete(id : number): Promise<number>{
      console.log(`${environment.apiUrl}/Candidate/${id}`);
      return fetch(`${environment.apiUrl}/Candidate/${id}`, {
        method: 'DELETE'
      })
      .then(resp => resp.json());
  }

}
