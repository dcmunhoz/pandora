import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { RegisterNewUserRequest } from './requests/register-new-user.request';
import { IUser } from '../../models/user.model';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from './requests/login.request';
import { IAuthenticatedUser } from '../../models/authenticated-user.model';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private _apiBase: string = '';

  constructor(private readonly _http: HttpClient) {
    this._apiBase = environment.apiBase + '/auth';
  }

  public register(request: RegisterNewUserRequest): Observable<IUser> {
    return this._http.post<IUser>(this._apiBase + '/signup', request);
  }

  public login(request: LoginRequest): Observable<IAuthenticatedUser> {
    return this._http.post<IAuthenticatedUser>(this._apiBase + '/login', request);
  }

  public saveToken(user: IAuthenticatedUser): void {
    if (localStorage.getItem('auth')) {
      localStorage.removeItem('auth');
    }

    localStorage.setItem('auth', JSON.stringify(user));
  }

  public isAuthenticated(): boolean {
    return !!localStorage.getItem('auth');
  }

  public getAuthentication(): IAuthenticatedUser {
    return JSON.parse(localStorage.getItem('auth') as string) as IAuthenticatedUser;
  }
}
