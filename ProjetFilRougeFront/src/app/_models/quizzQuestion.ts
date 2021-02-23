export class QuizzQuestion{
    private _idQuizz: number;
    private _idQuestion: number;
    private _comment: string;
    private _isCorrectAnswer: boolean;
    private _answerCandidate: string;

    constructor(idQuizz : number, idQuestion: number, comment: string, isCorrectAnswer: boolean, answerCandidate: string){
        this._idQuizz = idQuizz;
        this._idQuestion = idQuestion;
        this._comment = comment;
        this._isCorrectAnswer = isCorrectAnswer;
        this._answerCandidate= answerCandidate
    }

    get idQuizz(): number{
        return this._idQuizz;
    }
    get idQuestion(): number{
        return this._idQuestion;
    }
    get comment(): string{
        return this._comment;
    }
    get isCorrectAnswer(): boolean{
        return this._isCorrectAnswer;
    }
    get answerCandidate(): string{
        return this._answerCandidate;
    }
}