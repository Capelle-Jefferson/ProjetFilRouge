import { Component, Input, OnInit } from '@angular/core';
import { Candidate } from 'src/app/_models/candidate';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {

  @Input() candidate : Candidate;
  constructor() { }

  ngOnInit(): void {
  }

}
