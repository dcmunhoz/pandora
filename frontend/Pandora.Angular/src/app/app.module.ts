import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import PButtonModule from './common/components/p-button/p-button.module';
import PInputModule from './common/components/p-input/p-input.module';

@NgModule({
  declarations: [AppComponent],
  imports: [FormsModule, ReactiveFormsModule, BrowserModule, PInputModule, PButtonModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
