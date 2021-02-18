import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { observable } from 'rxjs';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-form-authentification',
  templateUrl: './form-authentification.component.html',
  styleUrls: ['./form-authentification.component.css']
})
export class FormAuthentificationComponent implements OnInit {

  userAuth: FormGroup;
  user: User = undefined;

  constructor(
    private builder: FormBuilder,
    private service: UserService
  ) {
    this.userAuth = this.builder.group({
      username: [""],
      password: [""]
    })
  }

  ngOnInit(): void {
  }

  async onSubmit() {
    try {
      await this.service.getAuthentification(this.userAuth.value).then((user) => this.user = user);

      // Si utilisateur reconnus
      if (!this.user['status']) {
        sessionStorage.setItem("user", JSON.stringify(this.user));
        location.reload();

      // Si utilisateur non reconnus
      } else {
        this.userAuth.getError("Identifiant non valide");
        alert("Identifiant non valide");
      }

    } catch {
      this.userAuth.getError("Erreur de connexion");
      alert("Erreur de connexion");
    }
  }
}
