import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmailService } from 'src/app/_services/email.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-demande-adhesion',
  templateUrl: './demande-adhesion.component.html',
  styleUrls: ['./demande-adhesion.component.css']
})
export class DemandeAdhesionComponent implements OnInit {

  sendForm: FormGroup;

  constructor(private builder : FormBuilder,
    private router : Router,
    private toastr : ToastrService,
    private serviceEmail : EmailService,
    private userservice:UserService) { }

  ngOnInit(): void {
    this.sendForm = this.builder.group({
      email: ["email-admin@gmail.com", Validators.email],
      subject: ["Test technique", Validators.required],
      message: [
        "Bonjour " +  + ",\n\n" +
        "Je souhaite créer un compte pour l'application Projet Fil rouge\n\n"+
        "Voici les informations nécessaires:\n"+
        "nom: \n"+
        "Prenom: \n"+
        "Email: \n" + 
        `\n\n\n`+
        "Bien cordialement,\n\n"
        // `Valeur rentrée dans le input ${valeur rentrée dans le input}.`+
        // "",
        //  Validators.required
      ]
    })
  }

  onSubmit(){
    console.log("kok");
  }
  // async onSubmit(){
  //   let res : Boolean
  //   await this.serviceEmail.sendEmail(this.sendForm.value).then(data => res = data)
  
  //   if(res){
  //     this.toastr.success("L'email à bien été envoyé");
  //     this.router.navigateByUrl('/CandidatesComponent', { skipLocationChange: true}).then(() => {
  //       this.router.navigate(["/candidats"]);
  //     })
  //   }else{
  //     this.toastr.error("L'email n'a pas était envoyé");
  //   }
  // }
}


