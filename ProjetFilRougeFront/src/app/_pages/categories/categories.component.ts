import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categories : Category[]
  deleteIcon = "../assets/images/icons/trash.svg";
  msgError = ""

  constructor(
     private services : CategoryService,
     private router: Router,
     private toastr: ToastrService
    ) { 
  }

  ngOnInit(): void {
    this.services.getAll().then(data => this.categories = data);
  }

  async deleteCategory(cat : Category){
    let res = true;
    await this.services.delete(cat.idCategory).catch(error => res = false);
    if(res){
      this.toastr.success("La catégorie à bien était supprimé");
      this.router.navigateByUrl('/CategoryComponent', { skipLocationChange: true}).then(() => {
        this.router.navigate(["/categories"]);
      })

    }else{
      this.toastr.error("Cette catégorie ne peut être supprimé !");
      this.msgError = "la catégorie " + cat.nameCategory + " est affecté à une ou plusieurs questions, elle ne peut donc être supprimé."
    }
  }

}
