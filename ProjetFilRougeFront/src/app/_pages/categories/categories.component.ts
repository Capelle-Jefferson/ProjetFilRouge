import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categories : Category[]
  deleteIcon = "../assets/images/icons/trash.svg";

  constructor(
     private services : CategoryService,
     private router: Router
    ) { 
  }

  ngOnInit(): void {
    this.services.getAll().then(data => this.categories = data);
  }

  deleteCategory(cat : Category){
    let res : Number;
    this.services.delete(cat.idCategory).then(data => res = data );
    this.router.navigateByUrl('/CategoryComponent', { skipLocationChange: true}).then(() => {
      this.router.navigate(["/categories"]);
    })
  }

}
