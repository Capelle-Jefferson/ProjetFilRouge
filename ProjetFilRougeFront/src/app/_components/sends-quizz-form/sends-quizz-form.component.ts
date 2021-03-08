import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CandidateService } from 'src/app/_services/candidate.service';
import { EmailService } from 'src/app/_services/email.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sends-quizz-form',
  templateUrl: './sends-quizz-form.component.html',
  styleUrls: ['./sends-quizz-form.component.css']
})
export class SendsQuizzFormComponent implements OnInit {

  @Input() candidate;
  @Input() codeQuizz;
  sendForm: FormGroup;
  ms : string
  private sub : any;
  userJson = sessionStorage['user'];
  user = JSON.parse(this.userJson);

  constructor(
    private builder : FormBuilder,
    private router : Router,
    private toastr : ToastrService,
    private serviceCandidate : CandidateService,
    private serviceEmail : EmailService
  ) { 
  }

  ngOnInit(): void {

    this.sendForm = this.builder.group({
      email: [this.candidate.email, Validators.email],
      subject: ["Test technique", Validators.required],
      message: [
        "Bonjour " + this.candidate.firstname + ",\n\n" +
        "Nous vous invitons à passer un test technique.\n\n"+
        "Voici le lien vous permettant d'y accèder:\n"+
        `${environment.siteUrl}/quiz\n\n`+
        "Ainsi que votre code d'accès: \n" + 
        `${this.codeQuizz}\n\n\n`+
        "Bien cordialement,\n\n"+
        `${this.user.lastname} ${this.user.firstname}.`+
        "",
         Validators.required
      ]
    })
  }

  async onSubmit(){
    let res : Boolean
    await this.serviceEmail.sendEmail(this.sendForm.value).then(data => res = data)
  
    if(res){
      this.toastr.success("L'email à bien été envoyé");
      this.router.navigateByUrl('/CandidatesComponent', { skipLocationChange: true}).then(() => {
        this.router.navigate(["/candidats"]);
      })
    }else{
      this.toastr.error("L'email n'a pas était envoyé");
    }
  }

}
