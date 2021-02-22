import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Quizz } from 'src/app/_models/quizz';
import { User } from 'src/app/_models/user';
import { QuizzService } from 'src/app/_services/quizz.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-generates-quizzes',
  templateUrl: './generates-quizzes.component.html',
  styleUrls: ['./generates-quizzes.component.css']
})
export class GeneratesQuizzesComponent implements OnInit {

  private sub: any;
  idUser: number;
  user: User;
  quizzes: Quizz[];
  deleteIcon = "../assets/images/icons/trash.svg";

  constructor(
    private route: ActivatedRoute,
    private service: QuizzService,
    private serviceUser: UserService
    ) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.idUser = +params['id'];
      this.service.getUserQuizz(this.idUser).then(data => this.quizzes = data);
    })
    this.serviceUser.get(this.idUser).then(data => this.user);
  }

  delete(quizz: Quizz){

  }

}
