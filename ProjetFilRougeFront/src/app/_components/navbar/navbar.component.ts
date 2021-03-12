import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  userJson = sessionStorage['user'];
  user = JSON.parse(this.userJson);
  admin = this.user.role == "ADMINISTRATEUR"

  constructor() { }

  ngOnInit(): void {
  }

  logout() {
    sessionStorage.clear();
    location.replace("");
  }

}
