import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { UserProfileService } from '../services/userprofile.service'
import { IUserProfile } from "../models/userprofile";

@Component({
    templateUrl: './edit-profile.template.html',
    styleUrls: ['./edit-profile.styles.scss']
})


export class EditProfileComponent implements OnInit {
    //This is to load all the controls
    private profileForm: FormGroup;

    constructor(private actRouter: ActivatedRoute, private router: Router, private upService: UserProfileService, private _fb: FormBuilder) {
    }


    ngOnInit() {
        this.profileForm = this._fb.group({
            userName: ['pmd@tiqri.com', [Validators.required]],
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
            }
            //Collecting USERNAME from session
           


            //userProfileObj.
            console.log(userProfileObj.ProfileName);
            
            this.upService.SaveUserProfile(userProfileObj).subscribe((res: any) => {
                console.log(res);
            }, error => {
                console.log('error when saving' + error);
            });
        }
    }
}