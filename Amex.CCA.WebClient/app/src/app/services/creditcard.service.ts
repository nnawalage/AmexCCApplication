import { Injectable } from '@angular/core'
import { CreditCard } from '../models/creditcard';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
//import { IToken } from "../models/token";

@Injectable()
export class CrediCardService {

    constructor(private http: Http) {

    }

    SaveCreditCard(creditCard: CreditCard): Observable<any> {
        let url = 'http://localhost:8947/api/CreditCards';
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, creditCard)
            .map(res => res.json());
    }

  
}