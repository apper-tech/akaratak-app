import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { TokenService } from 'src/app/shared/services/token.service';
import { MatSnackBar } from '@angular/material';

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(public token: TokenService,
        public snackBar: MatSnackBar,
        public router: Router) { }

    canActivate(): boolean {
        if (!this.token.hasToken()) {
            this.router.navigate(['login']);
            this.snackBar.open('You need to login for that!', '×',
                { panelClass: 'error', verticalPosition: 'top', duration: 3000 });
            return false;
        }
        return true;
    }
}