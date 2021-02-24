export class ChoiceAnswers {
    private _id:number;
    private _textAnswer : string;
    private _isAnswer : boolean;

    constructor(textAnswer:string,isAnswer:boolean,id:number){
        
        this._textAnswer=textAnswer;
        this._isAnswer=isAnswer;
        this._id=id;
    }

    get id():number{
        return this._id;
    }
    get textAnswer():string{
        return this._textAnswer;
    }
    get isAnswer():boolean{
        return this._isAnswer;
    }
    set id(id:number){
        this._id=id;
    }
    set textAnswer(textAnswer:string){
        this._textAnswer=textAnswer;
    }
    set isAnswer (isAnswer:boolean){
        this._isAnswer=isAnswer;
    }
}