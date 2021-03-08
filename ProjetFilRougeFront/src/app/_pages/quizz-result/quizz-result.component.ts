import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuizzResult } from 'src/app/_models/QuizzResult';
import { QuizzService } from 'src/app/_services/quizz.service';
import { jsPDF } from "jspdf";
import html2canvas from 'html2canvas';
import { Candidate } from 'src/app/_models/candidate';
import { CandidateService } from 'src/app/_services/candidate.service';
import { Quizz } from 'src/app/_models/quizz';


@Component({
  selector: 'app-quizz-result',
  templateUrl: './quizz-result.component.html',
  styleUrls: ['./quizz-result.component.css']
})
export class QuizzResultComponent implements OnInit {

  private sub: any;
  idQuizz : number;
  results : QuizzResult;
  idCandidate : number; // Pour récupérer le nom du candidat dans les résultats.
  candidate:Candidate;
  candidateName:string;

  // Charts
  type="PieChart";
  data : any;
  columnNames = ['Niveau', 'Pourcentage'];
  options = {
    
  }
  width = 1000;
  height = 600;


  constructor(
    private service : QuizzService,
    private candidatService:CandidateService,
    private route : ActivatedRoute
  ) { }

  async ngOnInit(){
    this.sub = this.route.params.subscribe(params => {
      this.idQuizz = +params['idQuizz'];
    })
    this.idCandidate = +localStorage.getItem("idCandidate");
    await  this.candidatService.get(this.idCandidate).then(response => this.candidate=response);
    this.candidateName= this.candidate.firstname +' '+ this.candidate.lastname;
    
    await this.service.getQuizzResult(this.idQuizz).then(data => this.results = data);

    let juniorP = this.results.resultJunior < 0 ? 0 : this.results.resultJuniorTotal * (this.results.resultJunior / 100)
    let confirmeP = this.results.resultConfirme < 0 ? 0 : this.results.resultConfirmeTotal * (this.results.resultConfirme / 100)
    let expertP = this.results.resultExpert < 0 ? 0 : this.results.resultExpertTotal * (this.results.resultExpert / 100)
    let restes = 100 - juniorP - confirmeP -expertP ;

    this.data = [
      ["Bonnes réponses, difficulté junior", juniorP],

      ["Bonnes réponses, difficulté confirmé", confirmeP],

      ["Bonnes réponses, difficulté expert", expertP],

      ["Mauvaises réponses", restes],
    ]
  }

  generatePdf(){
    let titre = this.candidateName;
    // Fait une capture d'écran de la page Html
    html2canvas(document.getElementById("result"),{width:1000,height:900}).then(function(canvas) {
    var img = canvas.toDataURL('image/png'); // Récupère l'url de la page
    var doc = new jsPDF({orientation:'portrait', unit:'mm',format:'a4'});
     // Ajoute la capture d'écran au pdf
     doc.addImage(img,'JPEG',0,0,220,220);
    // Enregistre le pdf avec le nom souhaité quand on le télécharge
    doc.save(`resultats_${titre}.pdf`)//+this.candidate.firstname+'_'+this.candidate.lastname+'.pdf') 
  });
  }

  
}
