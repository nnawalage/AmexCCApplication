import { Component, OnInit } from '@angular/core'
import { FormGroup, FormBuilder, FormControl, Validators, Validator, AbstractControl } from '@angular/forms'
import {Router } from '@angular/router'
import { UserProfileService } from '../services/userprofile.service'
import { Role } from '../models/Role'
import { IRegistration } from '../models/registration'


@Component({
    templateUrl: './user-registration.template.html',
    styleUrls: ['./user-registration.styles.scss']
})
export class UserRegistrationComponent implements OnInit {
    private registrationForm: FormGroup;
    private roles: string[] = []
    private selectedRole: string;

    constructor(private formBuilder: FormBuilder, private userProfileService: UserProfileService, private router:Router) { }



    // ngOnInit() {
    //     let passwordPattern: string = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&]).{8,}";

    //     this.registrationForm = this.formBuilder.group({
    //         profileName: ['', [Validators.required]],
    //         email: ['', Validators.compose([Validators.required, Validators.email])],
    //         password: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
    //         confirmPassword: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
    //         role: [Validators.required]
    //     });
    //     this.loadRoles();
    // }


    // ngOnInit() {
    //     let passwordPattern: string = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&]).{8,}";

    //     this.registrationForm = this.formBuilder.group({
    //         profileName: ['', [Validators.required]],
    //         email: ['', Validators.compose([Validators.required, Validators.email])],
    //         password: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
    //         confirmPassword: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern), this.checkPasswordMatch])],
    //         role: [Validators.required]
    //     });
    //     this.loadRoles();
    // }

    ngOnInit() {
        let passwordPattern: string = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&]).{8,}";

        this.registrationForm = this.formBuilder.group({
            profileName: ['', [Validators.required]],
            email: ['', Validators.compose([Validators.required, Validators.email])],
            password: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
            confirmPassword: [''],
            role: [Validators.required]
        });

        //    let ctrl:FormControl =<FormControl> this.registrationForm.controls['password'];

        this.registrationForm.controls['confirmPassword'].setValidators([Validators.required, Validators.pattern(passwordPattern), this.checkPasswordMatch(<FormControl>this.registrationForm.controls['password'])]);
        this.loadRoles();
    }


    // ngOnInit() {
    //     let passwordPattern: string = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&]).{8,}";

    //     this.registrationForm = this.formBuilder.group({
    //         profileName: ['', [Validators.required]],
    //         email: ['', Validators.compose([Validators.required, Validators.email])],
    //         // passwords: this.formBuilder.group({
    //         //     password: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
    //         //     confirmPassword: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
    //         // },{Validator:this.checkPasswordMatch}),
    //         password: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
    //         confirmPassword: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
    //         role: [Validators.required]
    //     },{Validator:this.checkPasswordMatch});
    //     this.loadRoles();
    // }

    private loadRoles(): void {
        this.userProfileService.getRoles().subscribe(
            (roleList: Role[]) => {
                roleList.map((roleItem: Role) => {
                    this.roles.push(roleItem.Name);
                });
                this.selectedRole = "User";
            }, error => console.log(error));
    }

    private onRegistrationSubmit(registrationFormValues: Object): void {
        if (this.registrationForm.valid) {
            let registrationModel: IRegistration = {
                ProfileName: registrationFormValues["profileName"],
                Email: registrationFormValues["email"],
                Password: registrationFormValues["password"],
                ConfirmPassword: registrationFormValues["confirmPassword"],
                RoleName: registrationFormValues["role"]
            };
          this.userProfileService.registerUser(registrationModel).subscribe((res: any) => {
            console.log(res);
            alert("Successfully registered user");
            this.router.navigate(['login']);

        }, error => {
            console.log('error when saving' + error);
        });
        }
    }

    // private checkPasswordMatch(group:FormGroup): any {
    //     let a=1;
    //     // let pass =this.registrationForm.controls.password.value;
    //     // let confirmPass = this.registrationForm.controls.confirmPassword.value;
    //     // return pass === confirmPass ? null : { passwordsDoNotMatch: true };
    // }

    //     checkPasswordMatch(group: FormGroup) { // here we have the 'passwords' group
    //     let pass = group.controls.password.value;
    //     let confirmPass = group.controls.confirmPass.value;

    //     return pass === confirmPass ? null : { notSame: true }     
    //   }

    private onConfirmPasswordChange(ctrl: FormControl) {

        ctrl.updateValueAndValidity();
    }

    private checkPasswordMatch(pass: FormControl): any {
        // if (this && this.registrationForm && this.registrationForm.controls) {

        //     let pass = this.registrationForm.controls.password.value;
        //     let confirmPass = control.value;
        //     return pass === confirmPass ? null : { 'passwordsDoNotMatch': true };
        // }
        return (confirmPass: FormControl): { [key: string]: any } => {
            if (confirmPass.value != '' && confirmPass.value != pass.value) {
                return { 'isInvalid': true };
            }
            return null;
        }
    }
}