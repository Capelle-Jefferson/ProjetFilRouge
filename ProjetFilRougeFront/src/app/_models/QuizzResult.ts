export class QuizzResult{
    private _resultTotal : number;
    private _resultJunior : number;
    private _resultConfirme : number;
    private _resultExpert : number;

    constructor(total : number, junior : number, confirme : number, expert : number){
        this._resultTotal = total;
        this._resultJunior = junior;
        this._resultConfirme = confirme;
        this._resultExpert = expert;
    }

    get resultTotal() : number {
        return this._resultTotal;
    }
    set resultTotal(resultTotal : number){
        this._resultTotal = resultTotal;
    }

    get resultJunior() : number {
        return this._resultJunior;
    }
    set resultJunior(resultJunior : number){
        this._resultJunior = resultJunior;
    }

    get resultConfirme() : number {
        return this._resultConfirme;
    }
    set resultConfirme(resultConfirme : number){
        this._resultConfirme = resultConfirme;
    }

    get resultExpert() : number {
        return this._resultExpert;
    }
    set resultExpert(resultExpert : number){
        this._resultExpert = resultExpert;
    }
}