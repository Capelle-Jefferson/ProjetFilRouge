import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Level } from 'src/app/_models/level';
import { LevelService } from 'src/app/_services/level.service';

@Component({
  selector: 'app-levels',
  templateUrl: './levels.component.html',
  styleUrls: ['./levels.component.css']
})
export class LevelsComponent implements OnInit {

  levels : Level[]
  deleteIcon = "../assets/images/icons/trash.svg";

  constructor(
     private services : LevelService,
     private router: Router,
     private toastr: ToastrService
    ) { 
  }

  ngOnInit(): void {
    this.services.getAll().then(data => this.levels = data);
  }

  deleteLevel(lev : Level){
    let res : Number;
    this.services.delete(lev.idLevel).then(data => res = data );
    this.router.navigateByUrl('/LevelComponent', { skipLocationChange: true}).then(() => {
      this.router.navigate(["/levels"]);
    this.toastr.success("Le level à bien était supprimé");
    })
  }

}
