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
            userName: ['un', [Validators.required]],
            profileName: ['pn', Validators.required],
            profileImage: ['pi'],
        })
    }

    private onSubmit(userProfileFormValues: Object): void {
        if (this.profileForm.valid) {
            let userProfileObj: IUserProfile = {
                UserName: userProfileFormValues['userName'],
                ProfileName: userProfileFormValues['profileName'],
                ProfileImage: userProfileFormValues['profileImage'],
            }
            console.log(userProfileObj.ProfileName);

            this.upService.SaveUserProfile(userProfileObj).subscribe((res: any) => {
                console.log(res);
            }, error => {
                console.log('error when saving' + error);
            });
        }
    }
}