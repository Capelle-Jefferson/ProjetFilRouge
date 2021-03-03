export class SendEmail{
    private _email : string;
    private _subject : string;
    private _message : string;


    constructor(email : string, subject : string, message : string){
        this._email = email;
        this._subject = subject;
        this._message = message;
    }

    get email(): string {
        return this._email;
    }
    set email(email : string){
        this._email = email;
    }

    get subject(): string {
        return this._subject;
    }
    set subject(subject : string){
        this._subject = subject;
    }

    get message(): string {
        return this._message;
    }
    set message(message : string){
        this._message = message;
    }
}