import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Candidate } from 'src/app/_models/candidate';
import { Level } from 'src/app/_models/level';
import { CandidateService } from 'src/app/_services/candidate.service';
import { LevelService } from 'src/app/_services/level.service';

@Component({
  selector: 'app-candidate-form',
  templateUrl: './candidate-form.component.html',
  styleUrls: ['./candidate-form.component.css']
})
export class CandidateFormComponent implements OnInit {

  levels: Level[]
  candidateForm: FormGroup
  userJson = sessionStorage['user'];
  user = JSON.parse(this.userJson);

  constructor(
    private builder: FormBuilder,
    private services: CandidateService,
    private router: Router,
    private toastr: ToastrService,
    private servicesLevels: LevelService
  ) {
    this.candidateForm = this.builder.group({
      firstname: ["", Validators.required],
      lastname: ["", Validators.required],
      email: ["", Validators.required],
      idLevel: [0]
    })
   }

  ngOnInit(): void {
    this.servicesLevels.getAll().then(data => this.levels = data);
  }

  onSubmit(){
    let cand : Candidate = this.candidateForm.value;
    cand.idUser = this.user.idUser;
    this.services.create(cand);
    this.router.navigateByUrl('/Candidats', { skipLocationChange: true}).then(() => {
      this.router.navigate(["/candidats"]);
    this.toastr.success("Le candidat à bien était ajouté");
    })
    
  }

}
