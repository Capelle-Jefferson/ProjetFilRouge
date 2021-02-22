export class Level{
    private _idLevel: number;
    private _nameLevel: string;

    constructor(name: string = '', id: number = 0){
        this._idLevel = id;
        this._nameLevel = name;
    }

    get idLevel(): number{
        return this._idLevel;
    }

    get nameLevel(): string{
        return this._nameLevel;
    }

    set nameLevel(name: string){
        this._nameLevel = name;
    }
}