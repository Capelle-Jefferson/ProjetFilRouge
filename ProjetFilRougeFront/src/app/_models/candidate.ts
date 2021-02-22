export class Candidate{
    private _idCandidate: number;
    private _firstname: string;
    private _lastname: string;
    private _email: string;
    private _idLevel: number;
    private _idUser: number;

    constructor(firstname: string, lastname: string, email: string, idLevel: number, idUser: number, id: number = 0){
        this._idCandidate = id;
        this._firstname = firstname;
        this._lastname = lastname;
        this._email = email;
        this._idLevel = idLevel;
        this._idUser = idUser;
    }

    get idCandidate(): number{
        return this._idCandidate;
    }

    get firstname(): string{
        return this._firstname;
    }
    get lastname(): string{
        return this._lastname;
    }
    get email(): string{
        return this._email;
    }
    get idLevel(): number{
        return this._idLevel;
    }
    get idUser(): number{
        return this._idUser;
    }

}