import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Candidate } from '../_models/candidate';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor() { }

  get(id: number) : Promise<Candidate>{
    return fetch(`${environment.apiUrl}/Candidate/${id}`).then(resp => resp.json());
  }

}
