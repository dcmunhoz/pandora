import { NgModule } from '@angular/core';
import { SignupRoutingModule } from './signup-routing.module';
import { SingUpComponent } from './feature/signup.component';
import PInputModule from 'src/app/common/components/p-input/p-input.module';
import PButtonModule from 'src/app/common/components/p-button/p-button.module';

@NgModule({
  imports: [SignupRoutingModule, PInputModule, PButtonModule],
  declarations: [SingUpComponent],
  exports: []
})
export class SignupModule {}
