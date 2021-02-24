import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Answers } from 'src/app/_models/Answers';
import { ChoiceAnswers } from 'src/app/_models/ChoiceAnswers';
import { Question } from 'src/app/_models/question';
import { QuestionsComponent } from 'src/app/_pages/questions/questions.component';
import { AnswerService } from 'src/app/_services/answer.service';
import { QuestionsService } from 'src/app/_services/questions.service';

@Component({
  selector: 'app-form-question',
  templateUrl: './form-question.component.html',
  styleUrls: ['./form-question.component.css']
})
export class FormQuestionComponent implements OnInit {

  questionForm: FormGroup;
  

  constructor(private fb: FormBuilder, private serviceQ:QuestionsService,private serviceA:AnswerService) {
    this.questionForm = this.fb.group({
      intitule: [""],
      idcategory:this.fb.control(""),
      idlevel: this.fb.control(""),
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
    this.listAnswers.push(this.fb.control(""));
  }
  addNewValidation() {
    this.listAnswers.push(this.fb.control(""));
  }
  onSubmit() { 
    
    //Création de la liste de choix multiples
    let choiceAnswer:ChoiceAnswers[]=[]
    var taille=this.listAnswers.length
    for(var i=0;i<taille;i++){
      let isAnswer:boolean;
      if(this.listAnswers.value[i]=="true"){
        isAnswer=true;
      }else{
        isAnswer=false;
      }
      let choice;
      choice={
        "textAnswer":this.listChoiceAnswer.value[i],
        "isAnswer":isAnswer
      }
      choiceAnswer.push(choice);
    }
    console.log(choiceAnswer)
    //Récupération des données pour la Answer
    let intituleS:string = this.questionForm.get("intitule").value
    let explicationS:string=this.questionForm.get("answer.explication").value
    let textAnswerS:string=this.questionForm.get("answer.textAnswer").value

    let answerF = {
      typeAnswer:+this.questionForm.get("answer.typeAnswer").value,
      explication:explicationS,
      textAnswer:textAnswerS,
      listChoiceAnswer:choiceAnswer
     }
     
     //Récupération des donnés pour la question
    let questionA={
       intitule:intituleS,
       idcategory: +this.questionForm.get("idcategory").value,
       idlevel: +this.questionForm.get("idlevel").value,
       answer:answerF
     }
    
     //Création de la question
     this.serviceQ.create(questionA);
     //this.serviceA.create(answerF);
  }
  
}
