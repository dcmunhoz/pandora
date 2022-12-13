import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { HttpInterceptorService } from './http-interceptor.service';

@NgModule({
  imports: [ToastrModule],
  declarations: [],
  exports: [],
  providers: [
    HttpInterceptorService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpInterceptorService,
      multi: true
    }
  ]
})
export class HttpInterceptorModule {}
