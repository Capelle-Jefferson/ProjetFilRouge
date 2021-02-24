import { Component, OnInit } from '@angular/core';
import { Candidate } from 'src/app/_models/candidate';
import { CandidateService } from 'src/app/_services/candidate.service';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {

  candidates : Candidate[] =[];
  constructor(private candidateService:CandidateService) { }

  ngOnInit(): void {
      this.candidateService.getAll().then(data => {
        this.candidates = data;
      })
  }

}
