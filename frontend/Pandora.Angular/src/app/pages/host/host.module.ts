import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HostComponent } from './feature/host.component';

@NgModule({
  imports: [BrowserModule, RouterModule],
  declarations: [HostComponent],
  exports: []
})
export class HostModule {}
