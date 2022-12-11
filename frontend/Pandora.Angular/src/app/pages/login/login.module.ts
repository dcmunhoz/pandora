import { NgModule } from '@angular/core';
import PButtonModule from 'src/app/common/components/p-button/p-button.module';
import { LoginComponent } from './feature/login.component';
import { LoginRouterModule } from './login-router.module';

@NgModule({
  imports: [LoginRouterModule, PButtonModule],
  declarations: [LoginComponent],
  exports: []
})
export class LoginModule {}
