import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  undefinedUser = false;

  constructor(
    private builder: FormBuilder,
    private service: UserService
  ) {
    this.userAuth = this.builder.group({
      username: ["", Validators.required],
      password: ["", Validators.required]
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
        this.undefinedUser = true;
      }

    } catch {
      this.undefinedUser = true;
      alert("Erreur de connexion");
    }
  }
}
