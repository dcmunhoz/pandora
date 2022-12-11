import { NgModule } from '@angular/core';
import { SignupRoutingModule } from './signup-routing.module';
import { SingUpComponent } from './feature/signup.component';
import PInputModule from 'src/app/common/components/p-input/p-input.module';
import PButtonModule from 'src/app/common/components/p-button/p-button.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PLoadingOverlayModyle } from 'src/app/common/components/p-loading-overlay/p-loading-overlay.module';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    SignupRoutingModule,
    PInputModule,
    PButtonModule,
    FormsModule,
    ReactiveFormsModule,
    PLoadingOverlayModyle
  ],
  declarations: [SingUpComponent],
  exports: []
})
export class SignupModule {}
