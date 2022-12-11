import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { RegisterNewUserRequest } from './requests/register-new-user.request';
import { IUser } from '../../models/user.model';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private _apiBase: string = '';

  constructor(private readonly _http: HttpClient) {
    this._apiBase = environment.apiBase + '/auth';
  }

  public register(request: RegisterNewUserRequest): Observable<IUser> {
    return this._http.post<IUser>(this._apiBase + '/signup', request);
  }
}
