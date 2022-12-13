import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import PButtonModule from 'src/app/common/components/p-button/p-button.module';
import { HostComponent } from './feature/host.component';

@NgModule({
  imports: [BrowserModule, RouterModule, PButtonModule],
  declarations: [HostComponent],
  exports: []
})
export class HostModule {}
