import { Injectable } from '@angular/core';
import * as  moment from 'moment'
import { UserDto } from './service.base';

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

  public setUser(user: UserDto) {
    localStorage.setItem('user_data', JSON.stringify(user));
  }
  public getUser(): UserDto {
    return JSON.parse(localStorage.getItem('user_data'));
  }



  public hasToken(): boolean {
    return new Date(localStorage.getItem('access_token_date')) ?
      new Date(localStorage.getItem('access_token_date')).getTime() >= new Date().getTime() :
      this.getToken() ? true : false;
  }
  public clearToken() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('access_token_date');
    localStorage.removeItem('user_data');
  }
}
