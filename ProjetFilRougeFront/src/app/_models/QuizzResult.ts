export class QuizzResult{
    private _resultTotal : number;
    private _resultJunior : number;
    private _resultJuniorTotal : number
    private _resultConfirme : number;
    private _resultConfirmeTotal : number
    private _resultExpert : number;
    private _resultExpertTotal : number

    constructor(total : number, junior : number, confirme : number, expert : number,
                juniorTotal : number, confirmeTotal : number, expertTotal:number)
    {
        this._resultTotal = total;
        this._resultJunior = junior;
        this._resultJuniorTotal = juniorTotal;
        this._resultConfirme = confirme;
        this._resultConfirmeTotal = confirmeTotal;
        this._resultExpert = expert;
        this._resultExpertTotal = expertTotal;
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


    get resultJuniorTotal() : number {
        return this._resultJuniorTotal;
    }
    set resultJuniorTotal(resultJuniorTotal : number){
        this._resultJuniorTotal = resultJuniorTotal;
    }

    get resultConfirmeTotal() : number {
        return this._resultConfirmeTotal;
    }
    set resultConfirmeTotal(resultConfirmeTotal : number){
        this._resultConfirmeTotal = resultConfirmeTotal;
    }

    get resultExpertTotal() : number {
        return this._resultExpertTotal;
    }
    set resultExpertTotal(resultExpertTotal : number){
        this._resultExpertTotal = resultExpertTotal;
    }


}