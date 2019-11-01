import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { TokenService } from 'src/app/shared/services/token.service';

@Injectable()
export class AppInterceptor implements HttpInterceptor {
  constructor(private tokenService: TokenService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (req.url.startsWith('/api/')) {
      req = req.clone({
        setHeaders: {
          Authorization: this.appendAuthToken()
        }
      });
    }
    console.log(req);

    return next.handle(req).pipe(map((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
        // console.log(`Request for ${req.urlWithParams} completed...`);
      }
      return event;
    }),
      catchError((error: HttpErrorResponse) => {
        const started = Date.now();
        const elapsed = Date.now() - started;
        //console.log(`Request for ${req.urlWithParams} failed after ${elapsed} ms.`);
        // debugger;
        return throwError(error);
      })
    );

  }
  private appendAuthToken(): string {
    const token = this.tokenService.getToken();
    if (token !== '') {
      const tokenValue = 'Bearer ' + token;
      return tokenValue;
    }
  }
}