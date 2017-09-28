export class UserApprove{
    ProfileName : string
    Email : string
    IsActive : boolean
    Image:string
    Id:string
    RoleId:string
    RoleName:string
    UsersRoles:UsersRoles[]
}
export class UsersRoles{
    Name: string
}