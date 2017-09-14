import { Injectable } from '@angular/core'
import { CreditCard } from '../models/creditcard';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ICardType } from "../models/cardtype";
import { INationality } from "../models/nationality";
import { HttpService } from '../services/index';

@Injectable()
export class CrediCardService {
     
    constructor(private http: HttpService) {
    }

    getCardTypes(): Observable<ICardType[]> {
        return this.http.get(`/CardType`).map((res: Response) => {
            return <ICardType[]>res.json();
        });

    }

    getNationalities(): Observable<INationality[]> {
        return this.http.get(`/Nationality`).map((res: Response) => {
            return <INationality[]>res.json();
        });
    }

    SaveCreditCard(creditCard: CreditCard): Observable<any> {
        let url = `/CreditCards`;
        return this.http.post(url, creditCard);
    }

}