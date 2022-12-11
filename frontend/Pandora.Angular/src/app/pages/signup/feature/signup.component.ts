import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/common/services/authentication/authentication.service';
import { RegisterNewUserRequest } from 'src/app/common/services/authentication/requests/register-new-user.request';

@Component({
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SingUpComponent {
  protected formUser: FormGroup;
  protected showLoading = false;

  constructor(
    private readonly _fb: FormBuilder,
    private readonly _authService: AuthenticationService,
    private readonly _notification: ToastrService,
    private readonly _route: Router
  ) {
    this.formUser = _fb.group({
      username: ['', [Validators.required, Validators.maxLength(16)]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmedPassword: ['', [Validators.required, Validators.minLength(8)]],
      email: ['', [Validators.required, Validators.email]],
      name: ['', Validators.required],
      lastName: ['', Validators.required]
    });
  }

  public registerUser(): void {
    if (this.formUser.invalid) {
      this._notification.error('Preencha todos os campos!', 'Atenção!');
      return;
    }

    this.showLoading = true;

    let request: RegisterNewUserRequest = this.formUser.value;

    this._authService.register(request).subscribe({
      next: response => {
        this._notification.success('Usuário cadastrado com sucesso!');
        this.formUser.reset();
        this._route.navigateByUrl('/login');
        this.showLoading = false;
      },
      error: (error: HttpErrorResponse) => {
        this._notification.error(error.error?.detail, error.error?.title);
        this.showLoading = false;
      },
      complete: () => {}
    });
  }
}
