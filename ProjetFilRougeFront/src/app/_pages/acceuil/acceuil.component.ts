import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmailService } from 'src/app/_services/email.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-acceuil',
  templateUrl: './acceuil.component.html',
  styleUrls: ['./acceuil.component.css']
})
export class AcceuilComponent implements OnInit {

  iconquizz="../assets/images/icons/iconquiz.svg"
  constructor() { }

  ngOnInit(): void {
  }

}
