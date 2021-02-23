import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Answers } from 'src/app/_models/Answers';
import { ChoiceAnswers } from 'src/app/_models/ChoiceAnswers';
import { QuestionsService } from 'src/app/_services/questions.service';

@Component({
  selector: 'app-form-question',
  templateUrl: './form-question.component.html',
  styleUrls: ['./form-question.component.css']
})
export class FormQuestionComponent implements OnInit {

  questionForm: FormGroup;
 
  

  constructor(private fb: FormBuilder, private service:QuestionsService) {
    this.questionForm = this.fb.group({
      intitule: [""],
      category: [""],
      level: this.fb.control(""),
      answer:this.fb.group({
        typeAnswer: this.fb.control(""),
        explication: [""],
        textAnswer: [""],
        listChoiceAnswer:this.fb.group({
          textAnswer:this.fb.array([this.fb.control("")]),
          isAnswer:this.fb.array([this.fb.control("",{updateOn:"change"})])
        })
      })
    })
        
  }

  ngOnInit(): void {
  }
  get listChoiceAnswer() :FormArray {
        return this.questionForm.get("answer.listChoiceAnswer.textAnswer") as FormArray;
    }
    get listAnswers() :FormArray {
      return this.questionForm.get("answer.listChoiceAnswer.isAnswer") as FormArray;
  }
  addNewReponse() {
    this.listChoiceAnswer.push(this.fb.control(""));
  }
  addNewValidation() {
    this.listAnswers.push(this.fb.control(""));
  }
  onSubmit() { 
      console.log(this.questionForm.value);
      //await this.service.create(this.questionForm.value).then((question) => this.questionForm = question);
  }
  attribuerValue(){
    
      // this.questionForm.setValue(this.questionForm.value.answer.listChoiceAnswer.isAnswer);
      // this.questionForm.setValue(this.questionForm.value.answer.listChoiceAnswer.textAnswer);
  }
    

  

  //   displayForm(){
  //     var div = document.getElementById("addRecruteur");
  //     if (div.style.display === "none") {
  //       div.style.display = "block";
  //     } else {
  //       div.style.display = "none";
  //     }
  // }

  //answer=>{
      //   this.listChoiceAnswer.push(new FormGroup({
      //     textAnswer:this.fb.control(""),
      //     isAnswer:this.fb.control("")
      //   }))
      // }])

      

}
