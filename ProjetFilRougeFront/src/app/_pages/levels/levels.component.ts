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

  async deleteLevel(lev : Level){
    let res =true;
    await this.services.delete(lev.idLevel).catch(error=>res=false);
    if(res){
      this.toastr.success("Le niveau à bien était supprimé");
    }else
    {
      this.toastr.error("Le niveau ne peut pas être supprimé");
    }
    this.router.navigateByUrl('/LevelComponent', { skipLocationChange: true}).then(() => {
    this.router.navigate(["/niveaux"]);
    })
  }

}
