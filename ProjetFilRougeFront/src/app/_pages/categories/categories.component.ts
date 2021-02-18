import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categories : Category[]
  deleteIcon = "../assets/images/icons/trash.svg";

  constructor(private services : CategoryService) { 
  }

  ngOnInit(): void {
    this.services.getAll().then(data => this.categories = data);
  }

}
