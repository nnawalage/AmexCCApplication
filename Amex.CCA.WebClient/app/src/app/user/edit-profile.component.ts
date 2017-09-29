import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { UserProfileService } from '../services/userprofile.service'
import { IUserProfile } from "../models/userprofile";
import { LoginService } from '../services/login.service';
import { IAttachments } from "../models/attachments";

@Component({
    templateUrl: './edit-profile.template.html',
    styleUrls: ['./edit-profile.styles.scss']
})

export class EditProfileComponent implements OnInit {
    //This is to load all the controls
    private profileForm: FormGroup;
    attachments: IAttachments[] = [];

    constructor(private actRouter: ActivatedRoute, private router: Router, private upService: UserProfileService, private _fb: FormBuilder, private loginService: LoginService) {
    }

    ngOnInit() {
        this.profileForm = this._fb.group({
            userName: ['cpk@tiqri.com', [Validators.required]],
            profileName: ['this is profile name', Validators.required],
            profileImage: [''],
        })
    }

    private onFileUpload(key, event: Event) {
        let fileList: FileList = event.target['files'];
        this.attachments.push({ key: key, fileList: fileList });
        console.log(this.attachments);
    }

    private onSubmit(userProfileFormValues: Object): void {
        if (this.profileForm.valid) {
            let userProfileObj: IUserProfile = {
                UserName: userProfileFormValues['userName'],
                ProfileName: userProfileFormValues['profileName'],
                ProfileImage: userProfileFormValues['profileImage'],
                //userProfileId: null,
                Attachments: this.attachments
            }

            //Collecting USERNAME, UserProfileID from session store
            userProfileObj.UserName = this.loginService.loggedUser.UserName;
            console.log(userProfileObj.UserName);
            userProfileObj.userProfileId = this.loginService.loggedUser.UserProfileId;

            if (userProfileObj.Attachments.length > 0) {
                this.upService.SaveUserProfile(userProfileObj).subscribe((res: any) => {
                    console.log(res);
                }, error => {
                    console.log('error when saving' + error);
                });
            }
            else {

            }
        }
    }
}