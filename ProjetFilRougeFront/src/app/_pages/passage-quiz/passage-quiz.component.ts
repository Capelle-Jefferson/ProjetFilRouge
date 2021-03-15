import { Component, Input, OnInit } from '@angular/core';
import { CheckboxRequiredValidator } from '@angular/forms';
import { Router } from '@angular/router';
import { Toast, ToastrModule, ToastrService } from 'ngx-toastr';
import { SendEmail } from 'src/app/_models/SendEmail';
import { CandidateService } from 'src/app/_services/candidate.service';
import { EmailService } from 'src/app/_services/email.service';
import { QuizzQuestionService } from 'src/app/_services/quizz-question.service';
import { QuizzService } from 'src/app/_services/quizz.service';
import { UserService } from 'src/app/_services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-passage-quiz',
  templateUrl: './passage-quiz.component.html',
  styleUrls: ['./passage-quiz.component.css']
})
export class PassageQuizComponent implements OnInit {

  @Input() quizz;
  istypeAnswer: boolean;
  isQcmUnique: boolean;
  Next: boolean = false;
  question: any;
  nombre: number = 0;
  isFinished: boolean = false;
  answerCandidate: string;
  lastPage: boolean = false;
  quizzDejaEffectue = ""


  constructor(
    private service: QuizzQuestionService, 
    private quizzService:QuizzService,
    private emailService : EmailService,
    private userService : UserService,
    private candidateService : CandidateService,
    private router : Router,
    private toastr : ToastrService
  ) { }

  ngOnInit(): void {
    this.suppresionLocalQuizz();
  }
  //Validation de la reponse à la question et passage à la question suivante
  async onSubmit() {
    await this.service.addCandidateAnswer(this.quizz.idQuizz, this.question.idQuestion, this.answerCandidate);
    this.nombre = this.nombre + 1;
    this.question = this.quizz.questions[this.nombre];
    this.Next = true;
    this.istypeAnswer = (this.question.answer.typeAnswer != "Text");
    this.isQcmUnique = (this.question.answer.typeAnswer != "QCM_multiple");
    if (this.nombre === this.quizz.questions.length - 1) {
      this.isFinished = true;
    }
  }
  //Enregistrement des réponses de QCM Multiple
  SaveAnswers = () => {
    this.answerCandidate="";
    var i,box;
    var boxes = document.getElementsByName("name");
    var checked=[]; 
    for (i=0; i < boxes.length; ++i) {
        box = boxes[i];
        if (box.name=="name" && box.checked) {
            checked.push(box.value);
        }
    }
    //Concatenation des valeurs des checkboxes
    this.answerCandidate=checked.join('§'); 
  }
 //Enregistrement de la réponses QCM unique 
  SaveAnswer(value: string) {
    this.answerCandidate = value;
  }
  //Enregistrement de la réponse dans les questions ouvertes
  SaveAnswerText = () => {
    this.answerCandidate = (<HTMLInputElement>document.getElementById("reponse")).value;
    (<HTMLInputElement>document.getElementById("reponse")).value = "";
  }

  //Damarrer le quizz à la question n°1
  goToFirstQuestion() {
    if(this.quizz.questions.length > this.nombre){
      this.question = this.quizz.questions[this.nombre];
      this.Next = true;
      this.istypeAnswer = this.question.answer.typeAnswer != "Text";
      this.isQcmUnique = this.question.answer.typeAnswer != "QCM_multiple";
    }else{
      location.reload();
      this.toastr.warning("Ce quiz a déjà été effectué")
    }
  }
  //Enregistrement de la dernière question et envoie en correction
  async FinduQuizz() {
    await this.service.addCandidateAnswer(this.quizz.idQuizz, this.question.idQuestion, this.answerCandidate);
    this.quizzService.correctQuiz(this.quizz.idQuizz);
    let user = await this.userService.get(this.quizz.idUser);
    let candidate = await this.candidateService.get(this.quizz.idCandidat);
    let email = {
      email: user.email,
      subject: "Test technique effectué",
      message:       "Bonjour, \n\n" +
      `Nous vous informons que ${candidate.lastname} ${candidate.firstname} a terminé le test technique.\n\n`+
      "Après connexion, vous pouvez accéder aux détails du quiz via l'url suivante:\n" + 
      `${environment.siteUrl}/gestionQuizz/details/${this.quizz.idQuizz}\n\n`+
      "Bien cordialement, \n\nL'équipe du projet fil rouge."
    }
    await this.emailService.sendEmail(email);
    this.Next = false;
    this.isFinished = false;
    this.lastPage = true;
  }
  // Suppresion de la variable local Quizz une fois le quizz completé
  suppresionLocalQuizz() {
    localStorage.removeItem("quizz");
  }
}
