export class Category{
    private _idCategory: number;
    private _nameCategory: string;

    constructor(name: string = '', id: number = 0){
        this._idCategory = id;
        this._nameCategory = name;
    }

    get idCategory(): number{
        return this._idCategory;
    }

    get nameCategory(): string{
        return this._nameCategory;
    }

    set nameCategory(name: string){
        this._nameCategory = name;
    }
}