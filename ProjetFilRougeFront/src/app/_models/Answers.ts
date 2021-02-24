import { ChoiceAnswers } from "./ChoiceAnswers";

export class Answers{
    private _id :number;
    private _typeAnswer :number;
    private _explication :string;
    private _textAnswer:string;
    private _listChoiceAnswer: ChoiceAnswers[];

    constructor(typeAnswer:number,explication:string,textAnswer:string,listChoiceAnswer:ChoiceAnswers[],id:number)
    {
        this._typeAnswer=typeAnswer;
        this._explication=explication;
        this._textAnswer=textAnswer;
        this._listChoiceAnswer=listChoiceAnswer;
        this._id=id;
    }

    get id():number{
        return this._id;
    }
    get typeAnswer():number{
        return this._typeAnswer
    }
    get explication():string{
        return this._explication
    }
    get textAnswer():string{
        return this._textAnswer
    }
    get listChoiceAnswer():ChoiceAnswers[]{
        return this._listChoiceAnswer;
    }
    set id(id:number){
        this._id=id;
    }
    set typeAnswer(typeAnswer:number){
        this._typeAnswer=typeAnswer;
    }
    set explication(explication:string){
        this._explication=explication;
    }
    set textAnswer(textAnswer:string){
        this._textAnswer=textAnswer;
    }
    set listChoiceAnswer(listChoiceAnswer:ChoiceAnswers[]){
        this._listChoiceAnswer=listChoiceAnswer;
    }
}