import {Component,OnInit} from '@angular/core'
import {FormGroup,FormBuilder,FormControl,Validators} from '@angular/forms'


@Component({
    templateUrl:'./user-registration.template.html',
    styleUrls:['./user-registration.styles.scss']
})
export class UserRegistrationComponent implements OnInit
{
    private registrationForm:FormGroup;
    private roles:string[]=[]

    constructor(private formBuilder:FormBuilder) {}

    ngOnInit()
    {
        this.registrationForm=this.formBuilder.group({
            profileName:['',[Validators.required]],
            email:['',[Validators.required],],
            password:['',[Validators.required]],
            confirmPassword:['',Validators.required],
            role:[Validators.required]
        });
        this.loadRoles();
    }

    loadRoles()
    {

    }
}