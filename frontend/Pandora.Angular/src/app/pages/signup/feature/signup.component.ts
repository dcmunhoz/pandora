import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/common/services/authentication/authentication.service';
import { RegisterNewUserRequest } from 'src/app/common/services/authentication/requests/register-new-user.request';

@Component({
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SingUpComponent {
  protected formUser: FormGroup;

  constructor(
    private readonly _fb: FormBuilder,
    private readonly _authService: AuthenticationService,
    private readonly _notification: ToastrService
  ) {
    this.formUser = _fb.group({
      username: ['', [Validators.required, Validators.maxLength(16)]],
      password: ['', Validators.required],
      confirmedPassword: ['', Validators.required],
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

    let request: RegisterNewUserRequest = this.formUser.value;

    this._authService.register(request).subscribe({
      next: response => {
        this._notification.success('Usuário cadastrado com sucesso!');
        this.formUser.reset();
      },
      error: (error: HttpErrorResponse) => {
        this._notification.error(error.error?.detail, error.error?.title);
      },
      complete: () => {}
    });
  }
}
