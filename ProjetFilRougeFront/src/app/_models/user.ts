export class User{
    private _idUser: number;
    private _username: string;
    private _password: string;
    private _firstname: string;
    private _lastname: string;
    private _email: string;
    private _idRoles: number;

    constructor(username: string = '', password: string = '', firstname: string = '', lastname: string = '', email: string = '',
                idRoles : number = 0, id: number = 0){
        this._idUser = id;
        this._username = username;
        this._password = password;
        this._firstname = firstname;
        this._lastname = lastname;
        this._email = email;
        this._idRoles = idRoles;
    }

    get id(): number{
        return this._idUser;
    }
    get idRoles(): number{
        return this._idRoles;
    }
    get username(): string{
        return this._username;
    }
    get password(): string{
        return this._password;
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

    set username(username: string){
        this._username = username;
    }
    set password(password: string){
        this._password = password;
    }
    set firstname(firstname: string){
        this._firstname = firstname;
    }
    set lastname(lastname: string){
        this._lastname = lastname;
    }
    set email(email: string){
        this._email = email;
    }
}