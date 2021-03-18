import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Candidate } from 'src/app/_models/candidate';
import { CandidateService } from 'src/app/_services/candidate.service';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {

  userJson = sessionStorage['user'];
  user = JSON.parse(this.userJson);
  admin = this.user.role == "ADMINISTRATEUR"
  candidates : Candidate[];
  deleteIcon = "../assets/images/icons/trash.svg";
  quizzIcon = "../assets/images/icons/quiz.svg";
  msgError = ""

  constructor(
    private candidateService:CandidateService,
    private router:Router,
    private toastr: ToastrService
  ) { }


  ngOnInit() {
    if(this.admin){
      this.candidateService.getAll().then(data => {
        this.candidates = data;
      })
    }else{
      this.candidateService.getByIdUser(this.user.idUser).then(data => {
        this.candidates = data;
      })
    }
  }

 async deleteCandidate(cand: Candidate){
    let res : Number;
    try{
      await this.candidateService.delete(cand.idCandidate).then(data => res = data );
      this.toastr.success("Le candidat à bien été supprimé");
    }catch{
      this.toastr.warning("Ce candidat ne peut pas être supprimé, il est associé à un quiz");
    }

    this.router.navigateByUrl('/CandidatesComponent', { skipLocationChange: true}).then(() => {
      this.router.navigate(["/candidats"]);
    })
  }

}
