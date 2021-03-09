import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-recruteurs',
  templateUrl: './recruteurs.component.html',
  styleUrls: ['./recruteurs.component.css']
})
export class RecruteursComponent implements OnInit {

  users : User[];
  deleteIcon = "../assets/images/icons/trash.svg";

  constructor(
    private userService : UserService,
    private router:Router,
    private toastr: ToastrService
  ) { }

  async ngOnInit() {
    await this.userService.getAllRecruteur().then(data => this.users = data);
  }

  async deleteUser(user : User){

  }

}
