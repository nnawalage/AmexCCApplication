import { Component, OnInit } from '@angular/core';
import 'rxjs';
import { UserProfileService } from '../services/userprofile.service';
import { UserApprove } from '../models/userApprove';
import { Role } from '../models/role';

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
    UserRoles: any[] =[]
    Appplicant:any[]=[]
    selectToApprove: boolean
    
    getRoles():void{
        this.userService.getRoles()
                        .subscribe(role =>{
                            this.Roles = role;
                        });
    }
    getInActiveUsers(): void {
        this.userService.getUsersToApprove()
            .subscribe(users => {
                this.assignRolesTORoleIds(users);
            });
    }
    ngOnInit(): void {
        this.getRoles();
        this.getInActiveUsers();
    }
    saveApproved(usersData:UserApprove[]):void{
        usersData.map(userData =>{
            if(userData.IsActive){
                    this.Roles.map(role =>{
                        if(role.Name == userData.RoleName){
                            userData.RoleId = role.Id;
                        }
                    });
                this.userService.saveApprovedUsers(userData,userData.Id)
                                .subscribe(users =>{
                                    console.log(users);
                                });
            }
        });  
    }
    addAllUsersToApprove(usersToApprove:UserApprove[],isChecked:boolean):void{
        if(isChecked){
             this.selectToApprove=true;
        }
        else{
            this.selectToApprove=false;
        }
    }
    assignRolesTORoleIds(users: UserApprove[]): void {
        this.usersToApprove = users
        this.usersToApprove.map(user=>{
            this.Roles.map(role =>{
                
                    if(role.Id == user.RoleId){
                        user.RoleName = role.Name
                        this.UserRoles.push(role.Name);
                    } 
            });
            this.Roles.map(role =>{
                var count=0;
                this.UserRoles.map(userrole =>{
                    if(userrole == role.Name){
                        count+=1;
                    }
                });  
                if(!(count >0)){
                    this.UserRoles.push(role.Name);
                }
            });
            user.UsersRoles = this.UserRoles;
            this.UserRoles=[];
        });
    }
    customTrackBy(index: number, obj: any): any {
        return index;
    }
}
