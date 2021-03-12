import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/_models/category';
import { ChoiceAnswers } from 'src/app/_models/ChoiceAnswers';
import { Level } from 'src/app/_models/level';
import { CategoryService } from 'src/app/_services/category.service';
import { LevelService } from 'src/app/_services/level.service';
import { QuestionsService } from 'src/app/_services/questions.service';

@Component({
  selector: 'app-form-question',
  templateUrl: './form-question.component.html',
  styleUrls: ['./form-question.component.css']
})
export class FormQuestionComponent implements OnInit {

  questionForm: FormGroup;
  levels:Level[];
  categories:Category[];
  

  constructor(private fb: FormBuilder, private serviceQ:QuestionsService,private servicesCategories : CategoryService,
    private servicesLevels: LevelService,private router:Router) {
    this.questionForm = this.fb.group({
      intitule: ["", Validators.required],
      idcategory:[null, [Validators.required]],
      idlevel: [null, [Validators.required]],
      answer:this.fb.group({
        typeAnswer: [null, [Validators.required]],
        explication: [""],
        textAnswer: [""],
        listChoiceAnswer:this.fb.group({
          textAnswer:this.fb.array([this.fb.control("")]),
          isAnswer:this.fb.array([this.fb.control("")])
        })
      })
    })
        
  }

  ngOnInit(): void {
    this.servicesCategories.getAll().then(data => this.categories = data);
    this.servicesLevels.getAll().then(data => this.levels = data);
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
  onSubmit() { 
    //Création de la liste de choix multiples
    let choiceAnswer:ChoiceAnswers[]=[]
    let compteur=0;
    var taille=this.listAnswers.length
    if(this.questionForm.value.answer.typeAnswer!= "text"){
      for(var i=0;i<taille;i++){
        let isAnswerC:boolean;
          if(this.listAnswers.value[i]=="true"){
            isAnswerC=true;
            compteur ++;
          }else{
            isAnswerC=false;
          }
        let choice;
        let textAnswerC:string=this.listChoiceAnswer.value[i]
        choice ={
          textAnswer:textAnswerC,
          isAnswer:isAnswerC
        }
      choiceAnswer.push(choice);
      }
    }else{
      choiceAnswer=null;
    }
    
    //Récupération des données pour la Answer
    console.log(this.questionForm.get("intitule").value);

    let intituleS:string = (this.questionForm.get("intitule").value) 
    let explicationS:string=this.questionForm.get("answer.explication").value
    let textAnswerS:string=this.questionForm.get("answer.textAnswer").value

    let typeAnswerForm = this.questionForm.get("answer.typeAnswer").value;
    if(typeAnswerForm == "qcm"){
      let nbIsCorrectAnswer = 0;
      for(let answ of choiceAnswer){
        if(answ.isAnswer){
          nbIsCorrectAnswer++;
        }
      }
      if(nbIsCorrectAnswer > 1){
        typeAnswerForm = "QCM_multiple"
      }
    }

    let answerF = {
      typeAnswer:typeAnswerForm,
      explication:explicationS,
      textAnswer:textAnswerS,
      listChoiceAnswer:choiceAnswer
     }
     
     //Récupération des donnés pour la question
    let questionA ={
       intitule:intituleS,
       idcategory: +this.questionForm.get("idcategory").value,
       idlevel: +this.questionForm.get("idlevel").value,
       answer:answerF
     }
     
     //Création de la question et redirection vers la page questions
     this.serviceQ.create(questionA);
     this.router.navigateByUrl("/QuestionsComponent", { skipLocationChange: true}).then(() => {
      this.router.navigate(["/questions"]);
    })
  }
}
