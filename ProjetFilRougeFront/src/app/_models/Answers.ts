import { ChoiceAnswers } from "./ChoiceAnswers";

export class Answers{
    private _id :number;
    private _typeAnswer :string;
    private _explication :string;
    private _textAnswer:string;
    private _listChoiceAnswer: ChoiceAnswers[];

    constructor(id:number,typeAnswer:string,explication:string,textAnswer:string,listChoiceAnswer:ChoiceAnswers[]){
        this._id=id;
        this._typeAnswer=typeAnswer;
        this._explication=explication;
        this._textAnswer=textAnswer;
        this._listChoiceAnswer=listChoiceAnswer;
    }

    get id(){
        return this._id;
    }
    get typeAnswer(){
        return this._typeAnswer
    }
    get explication(){
        return this._explication
    }
    get textAnswer(){
        return this._textAnswer
    }
    get listChoiceAnswer(){
        return this._listChoiceAnswer;
    }
    set id(id){
        this._id=id;
    }
    set typeAnswer(typeAnswer){
        this._typeAnswer=typeAnswer;
    }
    set explication(explication){
        this._explication=explication;
    }
    set textAnswer(textAnswer){
        this._textAnswer=textAnswer;
    }
    set listChoiceAnswer(listChoiceAnswer){
        this._listChoiceAnswer=listChoiceAnswer;
    }
}