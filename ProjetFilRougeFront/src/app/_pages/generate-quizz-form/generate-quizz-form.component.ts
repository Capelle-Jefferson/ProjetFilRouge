import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_models/category';
import { Level } from 'src/app/_models/level';
import { CategoryService } from 'src/app/_services/category.service';
import { LevelService } from 'src/app/_services/level.service';
import { QuizzService } from 'src/app/_services/quizz.service';

@Component({
  selector: 'app-generate-quizz-form',
  templateUrl: './generate-quizz-form.component.html',
  styleUrls: ['./generate-quizz-form.component.css']
})
export class GenerateQuizzFormComponent implements OnInit {

  private sub: any;
  quizzForm : FormGroup;
  categories: Category[];
  levels: Level[];
  userJson = sessionStorage['user'];
  user = JSON.parse(this.userJson);
  idCandidate: number;


  constructor(
    private builder: FormBuilder,
    private services: QuizzService,
    private servicesCategories : CategoryService,
    private servicesLevels: LevelService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute,
  ) { 
    this.quizzForm = this.builder.group({
      nbreQuestions: [0, Validators.required],
      idCategory: [0],
      idLevel: [0],
      idUser: [0],
      idCandidate: [0]
    })
    this.sub = this.route.params.subscribe(params => {
      this.idCandidate = +params['id'];
    })
  }

  ngOnInit(): void {
    this.servicesCategories.getAll().then(data => this.categories = data);
    this.servicesLevels.getAll().then(data => this.levels = data);
    this.idCandidate = +localStorage.getItem("idCandidate");
    localStorage.removeItem("idCandidate");
  }

  onSubmit() {
    let quizz = {
      idCategory: +this.quizzForm.get("idCategory").value,
      idLevel: +this.quizzForm.get("idLevel").value,
      idUser: this.user.idUser,
      idCandidat: this.idCandidate,
    }
    this.services.create(quizz, this.quizzForm.get("nbreQuestions").value);
    this.router.navigateByUrl(`/gestionQuizz/${this.idCandidate}`, { skipLocationChange: true}).then(() => {
      this.router.navigate([`/gestionQuizz/${this.idCandidate}`]);
    this.toastr.success("Le quizz à bien été généré");
    })
  }
}
