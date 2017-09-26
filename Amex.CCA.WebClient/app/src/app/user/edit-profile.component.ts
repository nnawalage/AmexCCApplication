import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { UserProfileService } from '../services/userprofile.service'
import { IUserProfile } from "../models/userprofile";
import { LoginService } from '../services/login.service';

@Component({
    templateUrl: './edit-profile.template.html',
    styleUrls: ['./edit-profile.styles.scss']
})


export class EditProfileComponent implements OnInit {
    //This is to load all the controls
    private profileForm: FormGroup;

    constructor(private actRouter: ActivatedRoute, private router: Router, private upService: UserProfileService, private _fb: FormBuilder, private loginService: LoginService) {
    }


    ngOnInit() {
        this.profileForm = this._fb.group({
            userName: ['cpk@tiqri.com', [Validators.required]],
            profileName: ['profilename1', Validators.required],
            profileImage: ['https://lh3.googleusercontent.com/RmjpzTM-vciDR8-B30N2Zbs3ZvVGrxkJQXirUlPMwGvZhSfmucp6D5V8MfgYNwlIqXY=w300'],
        })
    }

    private onSubmit(userProfileFormValues: Object): void {
        if (this.profileForm.valid) {
            let userProfileObj: IUserProfile = {
                UserName: userProfileFormValues['userName'],
                ProfileName: userProfileFormValues['profileName'],
                ProfileImage: userProfileFormValues['profileImage'],
                userProfileId:null
            }
            //Collecting USERNAME, UserProfileID from session store
            userProfileObj.UserName = this.loginService.loggedUser.UserName;
            userProfileObj.userProfileId = this.loginService.loggedUser.RoleId; //TESTING
            
            console.log(userProfileObj.UserName);

            this.upService.SaveUserProfile(userProfileObj).subscribe((res: any) => {
                console.log(res);
            }, error => {
                console.log('error when saving' + error);
            });
        }
    }
}