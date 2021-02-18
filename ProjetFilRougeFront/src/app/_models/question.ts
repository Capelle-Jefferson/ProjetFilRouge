import { Answers } from "./Answers";

export class Question {

    private _id : number;
    private _intitule :string;
    private _category:string;
    private _level:string;
    private _answer : Answers;

    constructor (id:number,intitule:string,category:string,level:string,answer:Answers){
        this._id=id;
        this._intitule=intitule;
        this._category=category;
        this._level=level;
        this._answer=answer;
    }

    get id(){
        return this._id;
    }
    get intitule(){
        return this._intitule;
    }
    get category(){
        return this._category;
    }
    get level(){
        return this._level;
    }
    get answer(){
        return this._answer;
    }

    set id(id){
        this._id=id;
    }
    set category(category){
        this._category=category;
    }
    set level(level){
        this._level=level;
    }
    set answer(answer){
        this._answer=answer;
    }

}