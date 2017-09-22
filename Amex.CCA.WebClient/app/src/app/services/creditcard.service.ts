import { Injectable } from '@angular/core'
import { ICreditCard } from '../models/creditcard';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ICardType } from "../models/cardtype";
import { INationality } from "../models/nationality";
// import { HttpService } from '../services/index';
import { HttpService } from '../services/http.service';

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

    SaveCreditCard(creditCard: ICreditCard): Observable<any> {
        let url = `/CreditCards`;
        return this.http.post(url, creditCard);
    }

    getAllCardRequests(): Observable<ICreditCard[]> {
        return this.http.get('/CreditCards')
            .map((res: Response) => {
                return <ICreditCard[]>res.json()
            });
           // .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

}
