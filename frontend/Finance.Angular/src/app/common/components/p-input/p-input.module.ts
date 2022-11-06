import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import PInputComponent from './p-input.component';

@NgModule({
  declarations: [PInputComponent],
  imports: [FormsModule],
  exports: [PInputComponent]
})
export default class PInputModule {}
