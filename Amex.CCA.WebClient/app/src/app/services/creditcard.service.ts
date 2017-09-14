import { Injectable } from '@angular/core'
import { CreditCard } from '../models/creditcard';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ICardType } from "../models/cardtype";
import { INationality } from "../models/nationality";
import { HttpService } from '../services/index';

import { environment } from '../../environments/environment';

@Injectable()
export class CrediCardService {
    private baseURI: string;
    
    // constructor(private http: Http) {

    // }
    
    constructor(private http: HttpService) {
        this.baseURI = environment.baseURI;
    }

    getCardTypes(): Observable<ICardType[]> {
        return this.http.get('http://localhost:8947/api/CardType').map((res: Response) => {
            let xx: any = { a: 1, b: 's', Name1: 'name' };
            // let aa: ICardType = <ICardType>xx;
            // let aa: ICardType = xx as ICardType;

            return <ICardType[]>res.json();
        }).catch(this.handleError);

    }

    getNationalities(): Observable<INationality[]> {
        return this.http.get('http://localhost:8947/api/Nationality').map((res: Response) => {
            return <INationality[]>res.json();
        }).catch(this.handleError);
    }

    SaveCreditCard(creditCard: CreditCard): Observable<any> {
        let url = 'http://localhost:8947/api/CreditCards';
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, creditCard)
            .map(res => res.json());
    }

    // SaveCreditCard(creditCard: CreditCard): Observable<any> {
    //     let url = `${this.baseURI}CreditCards`;
    //     // let headers = new Headers();
    //     // headers.append('Content-Type', 'application/json');
    //     // let options = new RequestOptions({ headers: headers });

    //     // return this.http.post(url, creditCard)
    //     //     .map(res => res.json());

    //     return this._http.post(url, creditCard);
    // }

    private handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json() || 'Server error');
    }


}