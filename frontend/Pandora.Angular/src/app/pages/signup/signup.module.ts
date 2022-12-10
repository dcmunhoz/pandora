import { NgModule } from '@angular/core';
import { SignupRoutingModule } from './signup-routing.module';
import { SingUpComponent } from './feature/signup.component';

@NgModule({
  imports: [SignupRoutingModule],
  declarations: [SingUpComponent],
  exports: []
})
export class SignupModule {}
