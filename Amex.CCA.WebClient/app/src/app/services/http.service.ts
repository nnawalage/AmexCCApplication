// import { Injectable } from '@angular/core';
// import { Http, Response,RequestMethod,RequestOptionsArgs } from '@angular/http';
// import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Injectable()
// export class HttpService {
export class HttpService extends Http {

    get(uri: string): Observable<Response> {
        return this.request(uri, RequestMethod.Get);
    }

    post(uri: string, body: any): Observable<Response> {
        return this.request(uri, RequestMethod.Post, body);
    }

    public request(url: string | Request, method: RequestMethod, body?: any, options?: RequestOptionsArgs): Observable<Response> {

        let token = this.getAuthToken();
        if (!options) {
            // let's make option object
            options = { headers: new Headers() };
        }
        options.method = method;
        options.headers.append('Content-Type', 'application/json; charset=utf-8');
        // options.headers.append('Accept', 'application/json; charset=utf-8');
        // options.headers.set('Olson-Timezone', timeZone);
        options.headers.set('Authorization', `Bearer ${token}`);

        if (body)
            options.body = body;

        return super.request(url, options).catch(this.catchError(this));
    }

    private getAuthToken() {
        let tokenObj = sessionStorage.getItem('authData');

        let key = JSON.parse(tokenObj);
        return key ? key.AccessToken : null;
    }

    // private handleError(error: Response) {
    //     console.log(error);
    //     return Observable.throw(error.json() || 'Server error');
    // }

    private catchError(self: HttpService) {
        // we have to pass HttpService's own instance here as `self`
        return (res: Response) => {
            console.log(res);
            if (res.status === 401 || res.status === 403) {
                // if not authenticated
                console.log(res);
            }
            return Observable.throw(res);
        };
    }


}
