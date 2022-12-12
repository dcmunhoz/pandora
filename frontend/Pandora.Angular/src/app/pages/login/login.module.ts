import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import PButtonModule from 'src/app/common/components/p-button/p-button.module';
import PInputModule from 'src/app/common/components/p-input/p-input.module';
import { PLoadingOverlayModyle } from 'src/app/common/components/p-loading-overlay/p-loading-overlay.module';
import { LoginComponent } from './feature/login.component';
import { LoginRouterModule } from './login-router.module';

@NgModule({
  imports: [
    CommonModule,
    LoginRouterModule,
    PButtonModule,
    PInputModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule,
    PLoadingOverlayModyle
  ],
  declarations: [LoginComponent],
  exports: []
})
export class LoginModule {}
