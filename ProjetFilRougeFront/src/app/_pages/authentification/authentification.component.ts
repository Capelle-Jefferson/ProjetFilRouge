import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmailService } from 'src/app/_services/email.service';
import { UserService } from 'src/app/_services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-authentification',
  templateUrl: './authentification.component.html',
  styleUrls: ['./authentification.component.css']
})
export class AuthentificationComponent implements OnInit {

  sendForm: FormGroup;

  constructor(private builder : FormBuilder,
    private router : Router,
    private toastr : ToastrService,
    private serviceEmail : EmailService,
    private userservice:UserService
  ) { }

  ngOnInit(): void {
    this.sendForm = this.builder.group({
      email: [`${environment.emailAdmin}`, Validators.email],
      subject: ["Demande adhésion", Validators.required],
      message: [
        "Bonjour " + ",\n\n" +
        "Je souhaite créer un compte pour l'application Projet Fil rouge\n\n"+
        "Voici les informations nécessaires:\n"+
        "Nom: <Votre nom> \n"+
        "Prénom: <Votre prénom>\n"+
        "Email: <Votre email>\n" + 
        `\n\n`+
        "Bien cordialement,\n\n",
        Validators.required
      ]
    })

  }

  displayForm(id){
    var div = document.getElementById(id);
    if (div.style.display === "none") {
      div.style.display = "block";
    } else {
      div.style.display = "none";
    }
  }

  async onSubmit(){
    let res : Boolean
    await this.serviceEmail.sendEmail(this.sendForm.value).then(data => res = data)
  
    if(res){
      this.toastr.success("L'email à bien été envoyé");
      location.replace("");
    }else{
      this.toastr.error("L'email n'a pas était envoyé");
    }
  }
}
