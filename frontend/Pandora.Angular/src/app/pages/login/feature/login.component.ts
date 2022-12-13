import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IAuthenticatedUser } from 'src/app/common/models/authenticated-user.model';
import { AuthenticationService } from 'src/app/common/services/authentication/authentication.service';
import { LoginRequest } from 'src/app/common/services/authentication/requests/login.request';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  protected formLogin: FormGroup;
  protected showLoading = false;

  constructor(
    private readonly _router: Router,
    private readonly _fb: FormBuilder,
    private readonly _notification: ToastrService,
    private readonly _authService: AuthenticationService
  ) {
    this.formLogin = this._fb.group({
      username: ['', [Validators.required, Validators.maxLength(16)]],
      password: ['', [Validators.required, Validators.maxLength(64)]]
    });
  }

  public login() {
    if (this.formLogin.invalid) {
      this._notification.warning('É necessário preencher o usuário e senha', 'Atenção');
      return;
    }

    var login: LoginRequest = this.formLogin.value;

    this.showLoading = true;

    this._authService.login(login).subscribe({
      next: (response: IAuthenticatedUser) => {
        this.showLoading = false;
        this._authService.saveToken(response);
      },
      error: (error: HttpErrorResponse) => {
        this._notification.error(error.error?.detail, error.error?.title);
        this.showLoading = false;
      }
    });
  }
}
