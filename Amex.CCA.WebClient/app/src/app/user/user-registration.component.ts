import { Component, OnInit } from '@angular/core'
import { FormGroup, FormBuilder, FormControl, Validators, Validator, AbstractControl } from '@angular/forms'
import { Router } from '@angular/router'
import { UserProfileService } from '../services/userprofile.service'
import { Role } from '../models/Role'
import { IRegistration } from '../models/registration'

@Component({
    templateUrl: './user-registration.template.html',
    styleUrls: ['./user-registration.styles.scss']
})
export class UserRegistrationComponent implements OnInit {
    registrationForm: FormGroup;
     roles: string[] = []
    selectedRole: string;

    constructor(private formBuilder: FormBuilder, private userProfileService: UserProfileService, private router: Router) { }

    ngOnInit() {
        let passwordPattern: string = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&]).{8,}";

        this.registrationForm = this.formBuilder.group({
            profileName: ['', [Validators.required]],
            email: ['', Validators.compose([Validators.required, Validators.email])],
            password: ['', Validators.compose([Validators.required, Validators.pattern(passwordPattern)])],
            confirmPassword: [''],
            role: [Validators.required]
        });

        this.registrationForm.controls['confirmPassword'].setValidators([Validators.required, Validators.pattern(passwordPattern), this.checkPasswordMatch(<FormControl>this.registrationForm.controls['password'])]);
        this.loadRoles();
    }

    
    private loadRoles(): void {
        this.userProfileService.getRoles().subscribe(
            (roleList: Role[]) => {
                roleList.map((roleItem: Role) => {
                    this.roles.push(roleItem.Name);
                });
                this.selectedRole = "User";
            }, error => console.log(error));
    }

    onRegistrationSubmit(registrationFormValues: Object): void {
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

    
    onConfirmPasswordChange(ctrl: AbstractControl) {
        ctrl.updateValueAndValidity();
    }

    private checkPasswordMatch(pass: FormControl): any {
        return (confirmPass: FormControl): { [key: string]: any } => {
            if (confirmPass.value != '' && confirmPass.value != pass.value) {
                return { 'isInvalid': true };
            }
            return null;
        }
    }

    goToLogin(): void {
        this.router.navigate(['login']);
    }
}
