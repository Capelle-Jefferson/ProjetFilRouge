import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-form-authentification',
  templateUrl: './form-authentification.component.html',
  styleUrls: ['./form-authentification.component.css']
})
export class FormAuthentificationComponent implements OnInit {

  userAuth : FormGroup;
  user : User;
  users: User[] = [];

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
    this.service.getAll().then(users => this.users = users);
  }

  onSubmit() {
    this.service.getAuthentification(this.userAuth.value).then(user => this.user = user)
  }

}
