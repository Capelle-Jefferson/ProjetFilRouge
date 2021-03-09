import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SendEmail } from 'src/app/_models/SendEmail';
import { User } from 'src/app/_models/user';
import { EmailService } from 'src/app/_services/email.service';
import { UserService } from 'src/app/_services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recruteur-form',
  templateUrl: './recruteur-form.component.html',
  styleUrls: ['./recruteur-form.component.css']
})
export class RecruteurFormComponent implements OnInit {

  userForm : FormGroup;
  msgError = "";

  constructor(
    private builder: FormBuilder,
    private services: UserService,
    private router: Router,
    private toastr: ToastrService,
    private emailService : EmailService
  ) { 
    this.userForm = builder.group({
      username: ["", Validators.required],
      firstname: ["", Validators.required],
      lastname: ["", Validators.required],
      email: ["", Validators.email]
    })
  }

  ngOnInit(): void {
  }

  async onSubmit(){
    let res = true;
    await this.services.create(this.userForm.value).catch(error => res = false);
    if(res){
      this.router.navigateByUrl('/RecruteursComponent', { skipLocationChange: true}).then(() => {
        this.router.navigate(["/recruteurs"]);
      this.toastr.success("Le recruteur a bien était ajouté, un email lui à était envoyé");
      })
    }else{
      this.toastr.error("Le recruteur n'a pas était ajouté");
      this.msgError = "Le recruteur n'a pas était ajouté, l'adresse email ou le nom d'utilisateur est déjà utilisé"
    }
  }

}
