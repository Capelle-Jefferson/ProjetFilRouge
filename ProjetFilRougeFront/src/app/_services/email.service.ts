import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SendEmail } from '../_models/SendEmail';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor() { }

  
  sendEmail(sendEmail : SendEmail):Promise<Boolean>{
    return fetch(`${environment.apiUrl}/SendEmail`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(sendEmail)
    })
    .then(resp => resp.json());
  }
}
