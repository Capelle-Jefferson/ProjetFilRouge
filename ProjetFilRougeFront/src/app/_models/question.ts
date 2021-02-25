import { Answers } from "./Answers";

export class Question {

    private _idQuestion : number;
    private _intitule :string;
    private _idcategory:number;
    private _idlevel:number;
    private _answer : Answers;

    constructor (intitule:string,category:number,level:number,answer:Answers,idQuestion:number){
        
        this._intitule=intitule;
        this._idcategory=category;
        this._idlevel=level;
        this._answer=answer;
        this._idQuestion=idQuestion
    }

    get idQuestion():number{
        return this._idQuestion;
    }
    get intitule():string{
        return this._intitule;
    }
    get idcategory():number{
        return this._idcategory;
    }
    get idlevel():number{
        return this._idlevel;
    }
    get answer():Answers{
        return this._answer;
    }

    set idQuestion(id:number){
        this._idQuestion=id;
    }
    set intitule(intitule:string){
        this._intitule=intitule;
    }
    set category(category:number){
        this._idcategory=category;
    }
    set level(level:number){
        this._idlevel=level;
    }
    set answer(answer:Answers){
        this._answer=answer;
    }

}