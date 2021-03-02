import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LevelService } from 'src/app/_services/level.service';

@Component({
  selector: 'app-level-form',
  templateUrl: './level-form.component.html',
  styleUrls: ['./level-form.component.css']
})
export class LevelFormComponent implements OnInit {

  levelForm : FormGroup;

  constructor(
    private builder: FormBuilder,
    private services: LevelService,
    private router: Router,
    private toastr: ToastrService
    ) {
    this.levelForm = this.builder.group({
      nameLevel: ["", Validators.required]
    })
   }

  ngOnInit(): void {
  }

  onSubmit() {
    this.services.create(this.levelForm.value);
    this.router.navigateByUrl('/LevelComponent', { skipLocationChange: true}).then(() => {
      this.router.navigate(["/niveaux"]);
      this.toastr.success("Le level à bien était ajouté");
    })
  }

}
