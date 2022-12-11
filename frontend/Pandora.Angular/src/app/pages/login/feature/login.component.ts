import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  protected formLogin: FormGroup;

  constructor(
    private readonly _router: Router,
    private readonly _fb: FormBuilder,
    private readonly _notification: ToastrService
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
  }
}
