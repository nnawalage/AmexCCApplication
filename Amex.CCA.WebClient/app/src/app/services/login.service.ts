import { Injectable } from '@angular/core'
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

@Injectable()
export class LoginService {

    constructor(private http: Http) {

    }
    GetUser(user: User): Observable<any> {
        let url = 'http://localhost:8947/Token';
        let grantType: string = 'password';
        let creds: string = 'grant_type=' + grantType + '&userName=' + 'pmd@tiqri.com' + '&password=' + '1qaz2wsx@A';
        let headers: any = new Headers();
            headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, creds, options).map(this.extractData).catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
    private handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}