import { Injectable } from '@angular/core'
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { HttpService } from '../services/http.service';
import { UserApprove } from '../models/userApprove'

@Injectable()
export class UserService {
     
    constructor(private http: HttpService) { }
    
    getUsersToApprove(): Observable <UserApprove[]>{
        return this.http.get(`/UserProfiles/approveUser`).map((res: Response) => {
            return <UserApprove[]>res.json();
        });
    }
}
