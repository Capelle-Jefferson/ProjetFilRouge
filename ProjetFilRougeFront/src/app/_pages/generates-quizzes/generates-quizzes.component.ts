import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Candidate } from 'src/app/_models/candidate';
import { Quizz } from 'src/app/_models/quizz';
import { User } from 'src/app/_models/user';
import { CandidateService } from 'src/app/_services/candidate.service';
import { QuizzService } from 'src/app/_services/quizz.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-generates-quizzes',
  templateUrl: './generates-quizzes.component.html',
  styleUrls: ['./generates-quizzes.component.css']
})
export class GeneratesQuizzesComponent implements OnInit {

  private sub: any;
  idCandidate: number;
  quizzes: Quizz[];
  deleteIcon = "../assets/images/icons/trash.svg";

  constructor(
    private route: ActivatedRoute,
    private service: QuizzService,
    private serviceUser: UserService,
    private serviceCandidate: CandidateService,
    ) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.idCandidate = +params['id'];
      this.service.getUserQuizz(this.idCandidate).then(data => this.quizzes = data);
    })
    localStorage.setItem("idCandidate", this.idCandidate.toString());
  }

  delete(quizz: Quizz){

  }

}
