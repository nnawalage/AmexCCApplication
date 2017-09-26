import { Injectable } from '@angular/core'
import { IUserProfile } from '../models/userprofile';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { HttpService } from '../services/http.service';
import { LoginService } from '../services/login.service';
import { UserApprove } from '../models/userApprove';


@Injectable()
export class UserProfileService {
    constructor(private http: HttpService) {
    }

    getAllUserProfiles(): Observable<IUserProfile[]> {
        return this.http.get('/UserProfiles')
            .map((res: Response) => {
                return <IUserProfile[]>res.json()
            });
    }

    SaveUserProfile(userProfile: IUserProfile): Observable<any> {
        let url = `/UserProfiles`;
        return this.http.post(url, userProfile);
    }
    getUsersToApprove(): Observable <UserApprove[]>{
        let url=`/UserProfiles/approveUser`
        return this.http.get(url)
                        .map((res: Response) => {
                              return <UserApprove[]>res.json();
        });
    }


}