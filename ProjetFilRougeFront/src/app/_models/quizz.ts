export class Quizz{
    private _idQuizz: number;
    private _codeQuizz : string;
    private _date: Date;
    private _idCategory: number;
    private _idLevel: number;
    private _idUser: number;
    private _idCandidate: number;

    constructor(codeQuizz : string, date: Date, idCategory : number, idLevel: number, idUser: number, idCandidate: number, idQuizz: number = null){
        this._idQuizz = idQuizz;
        this._codeQuizz = codeQuizz;
        this._date = date;
        this._idCategory = idCategory;
        this._idLevel = idLevel;
        this._idUser = idUser;
        this._idCandidate = idCandidate;
    } 

    get idQuizz(): number{
        return this._idQuizz;
    }
    get codeQuizz(): string{
        return this._codeQuizz;
    }
    get date(): Date{
        return this._date;
    }
    get idCategory(): number{
        return this._idCategory;
    }
    get idLevel(): number{
        return this._idLevel;
    }
    get idUser(): number{
        return this._idUser;
    }
    get idCandidate(): number{
        return this._idCandidate;
    }

    set codeQuizz(code : string){
        this._codeQuizz = code;
    }
    set date(date : Date){
        this._date = date;
    }
    set idCategory(idCategory : number){
        this._idCategory = idCategory;
    }
    set idLevel(idLevel : number){
        this._idLevel = idLevel;
    }
    set idUser(idUser : number){
        this._idUser = idUser;
    }
    set idCandidate(idCandidate : number){
        this._idCandidate = idCandidate;
    }
}