import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {

  categoryForm : FormGroup;

  constructor(private builder: FormBuilder) {
    this.categoryForm = this.builder.group({
      nameCategory: ["", Validators.required]
    })
   }

  ngOnInit(): void {
  }

  onSubmit() {
    
  }

}
