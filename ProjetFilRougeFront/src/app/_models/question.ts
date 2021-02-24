import { Answers } from "./Answers";

export class Question {

    private _id : number;
    private _intitule :string;
    private _idcategory:number;
    private _idlevel:number;
    private _answer : Answers;

    constructor (intitule:string,category:number,level:number,answer:Answers,id:number){
        
        this._intitule=intitule;
        this._idcategory=category;
        this._idlevel=level;
        this._answer=answer;
        this._id=id
    }

    get id():number{
        return this._id;
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

    set id(id:number){
        this._id=id;
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