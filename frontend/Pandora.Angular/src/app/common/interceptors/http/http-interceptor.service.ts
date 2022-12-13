import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpStatusCode
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../../services/authentication/authentication.service';

@Injectable({ providedIn: 'root' })
export class HttpInterceptorService implements HttpInterceptor {
  constructor(
    private readonly _authService: AuthenticationService,
    private readonly _notification: ToastrService,
    private readonly _router: Router
  ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let handler: Observable<HttpEvent<any>>;

    if (this._authService.isAuthenticated()) {
      let authentication = this._authService.getAuthentication();

      let authReq = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + authentication.token)
      });

      handler = next.handle(authReq);
    } else {
      handler = next.handle(req);
    }

    handler.subscribe({
      next: (response: any) => {
        if (response instanceof HttpResponse) {
          console.log('retorno ', response);
        }
      },
      error: (error: HttpErrorResponse) => {
        if (error.status == HttpStatusCode.Unauthorized) {
          this._router.navigateByUrl('/login');
          this._notification.error('É necessário fazer o login novamente.');
          return;
        }

        if (error.status != HttpStatusCode.Ok) {
          this._notification.error(error.error?.detail, error.error?.title);
          return;
        }
      }
    });

    return handler;
  }
}
