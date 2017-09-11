import { Injectable } from '@angular/core'
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { IToken } from "../models/token";

@Injectable()
export class LoginService {
    loggedUser: User = null;

    constructor(private http: Http) {

    }

    isUserAuthorised(): boolean {
        let token = sessionStorage.getItem('access-token');
        return !!token;
    }

    loginUser(user: User): Observable<IToken> {
        let url = 'http://localhost:8947/Token';
        let grantType: string = 'password';
        let creds: string = `grant_type=${grantType}&userName=${user.UserName}&password=${user.PassWord}`;
        let headers: any = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, creds, options).map(
            (response: Response) => {
                let res: any = response.json();
                let token: IToken = {
                    AccessToken: res['access_token'],
                    Expires: res['.expires'],
                    UserName: res['userName']
                };
                return token;
                //console.log(response);
            }).catch(this.handleError);
    }
    // isUserAuthorised(): boolean {
    //     return !!this.loggedUser;
    // }

    // loginUser(user: User): Observable<any> {
    //     let url = 'http://localhost:8947/Token';
    //     let grantType: string = 'password';
    //     let creds: string = `grant_type=${grantType}&userName=${user.UserName}&password=${user.PassWord}`;
    //     let headers: any = new Headers();
    //     headers.append('Content-Type', 'application/x-www-form-urlencoded');
    //     let options = new RequestOptions({ headers: headers });

    //     return this.http.post(url, creds, options).map(
    //         (response: Response) => {
    //             let res: any = response.json();
    //             let user: User = {
    //                 UserName: res['userName']
    //             };
    //             this.loggedUser = user;
    //             return user;
    //             //console.log(response);
    //         }).catch((error) => {
    //             return Observable.of(false);
    //         });
    // }


    private handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json() || 'Server error');
    }

}