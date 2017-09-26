import { Component, OnInit } from '@angular/core';
import { UserProfileService } from '../services/userprofile.service';
import { UserApprove } from '../models/userApprove';
import { Role }     from'../models/Role';

@Component({
    selector: 'user-approve',
    templateUrl: './user-approve.template.html',
    styleUrls: ['./user-approve.styles.scss']
})
export class UserApproveComponent implements OnInit {
    constructor(private userService: UserProfileService) { }
    private profileImage: string;
    usersToApprove: UserApprove[] = []
    approveUser: any =[]
    ApproveAll: any=[]
    Roles: Role[] =[]

    getInActiveUsers(): void{
            this.userService.getUsersToApprove()
                            .subscribe(users=>{
                                this.usersToApprove = users
                               console.log(this.usersToApprove);
                            });
    }
    getRoles():void{
        this.userService.getRoles()
                        .subscribe(role =>{
                            this.Roles = role;
                        });
    }
    ngOnInit(): void {
        this.getInActiveUsers();
        this.getRoles();
    }
    saveApproved():void{
        if(this.ApproveAll.length>0){
            console.log("ApproveAll",this.ApproveAll);
        }
        if(this.approveUser.length>0 && !(this.ApproveAll.length>0 )){
            console.log("approveUser",this.approveUser);
        }
    }
    addUsersToApprove(ID: string,isChecked:boolean):void{
        if(isChecked){
            this.approveUser.push(ID); 
        }
        else{
            this.approveUser.pop(ID);
        }
    }
    addAllUsersToApprove(usersToApprove:UserApprove[],isChecked:boolean):void{
        if(isChecked){
            usersToApprove.map(user=>{
                this.ApproveAll.push(user.Id);
            });
        }
        else{
            this.ApproveAll=[]
        }
    }
}