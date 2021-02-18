import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-form-question',
  templateUrl: './form-question.component.html',
  styleUrls: ['./form-question.component.css']
})
export class FormQuestionComponent implements OnInit {

  questionForm:FormGroup;

  constructor(private fb:FormBuilder ) {
    this.questionForm = this.fb.group({
      intitule :[""],
      category:this.fb.control(""),
      level:this.fb.control(""),
      answer:this.fb.group({
        type:this.fb.control(""),
      choixReponse:this.fb.array([this.fb.control("")])
      })
    }
    )
    }
    
  ngOnInit(): void {
  }

  get choixReponse(): FormArray {
        return this.questionForm.get('choixReponse') as FormArray;
      }
    
  addNewReponse(){
    this.choixReponse.push(this.fb.control(""));
  }
  onSubmit(){}

//   displayForm(){
//     var div = document.getElementById("addRecruteur");
//     if (div.style.display === "none") {
//       div.style.display = "block";
//     } else {
//       div.style.display = "none";
//     }
// }

}
