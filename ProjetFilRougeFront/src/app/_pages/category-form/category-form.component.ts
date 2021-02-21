import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/_services/category.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {

  categoryForm : FormGroup;

  constructor(
    private builder: FormBuilder,
    private services: CategoryService,
    private router: Router,
    private toastr: ToastrService
    ) {
    this.categoryForm = this.builder.group({
      nameCategory: ["", Validators.required]
    })
   }

  ngOnInit(): void {
  }

  onSubmit() {
    this.services.create(this.categoryForm.value);
    this.router.navigateByUrl('/CategoryComponent', { skipLocationChange: true}).then(() => {
      this.router.navigate(["/categories"]);
    this.toastr.success("La catégorie à bien était ajouté");
    })
  }

}
