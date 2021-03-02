import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sends-quizz-form',
  templateUrl: './sends-quizz-form.component.html',
  styleUrls: ['./sends-quizz-form.component.css']
})
export class SendsQuizzFormComponent implements OnInit {

  @Input() candidate;
  sendForm: FormGroup;

  constructor(
    private builder : FormBuilder,
    private router : Router,
    private toastr : ToastrService
  ) { 
    this.sendForm = this.builder.group({
      message: ["", Validators.required]
    })
  }

  ngOnInit(): void {
  }

  onSubmit(){

  }

}
