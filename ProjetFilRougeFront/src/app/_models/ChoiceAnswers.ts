export class ChoiceAnswers {
    private _id:number;
    private _textAnswer : string;
    private _isAnswer : boolean;

    constructor(id:number,textAnswer:string,isAnswer:boolean){
        this._id=id;
        this._textAnswer=textAnswer;
        this._isAnswer=isAnswer;
    }

    get id(){
        return this._id;
    }
    get textAnswer(){
        return this._textAnswer;
    }
    get isAnswer(){
        return this._isAnswer;
    }
    set id(id){
        this._id=id;
    }
    set textAnswer(textAnswer){
        this._textAnswer=textAnswer;
    }
    set isAnswer (isAnswer){
        this._isAnswer=isAnswer;
    }
}