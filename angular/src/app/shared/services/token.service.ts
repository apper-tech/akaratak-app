import { Injectable } from '@angular/core';
import * as  moment from 'moment'

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }

  public setToken(token: string, expireDate?: Date) {
    localStorage.setItem('access_token', token);
    localStorage.setItem('access_token_date', expireDate ? expireDate.toString()
      : moment().add(1, 'd').toDate().toString());
  }

  public getToken(): string {
    return localStorage.getItem('access_token');
  }

  public hasToken(): boolean {
    return new Date(localStorage.getItem('access_token_date')) ?
      new Date(localStorage.getItem('access_token_date')).getTime() >= new Date().getTime() :
      this.getToken() ? true : false;
  }
  public clearToken() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('access_token_date');
  }
}
