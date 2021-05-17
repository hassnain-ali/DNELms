import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthorizeService } from './authorize.service';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeInterceptor implements HttpInterceptor {
  constructor(private authorize: AuthorizeService, private _router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return from(
      this.authorize.getAccessToken()
        .subscribe(token => {
          const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
          const authRequest = req.clone({ headers });
          return next.handle(authRequest)
            .pipe(
              catchError((err: any) => {
                if (err && (err.status === 401 || err.status === 403)) {
                  this._router.navigate(['/unauthorized']);
                }
                throw new Error(err);
              })
            ).toPromise();
        })
    );
  }
  //intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //  return this.authorize.getAccessToken()
  //    .pipe(mergeMap(token => this.processRequestWithToken(token, req, next)));
  //}

  // Checks if there is an access_token available in the authorize service
  // and adds it to the request in case it's targeted at the same origin as the
  // single page application.
  private processRequestWithToken(token: string, req: HttpRequest<any>, next: HttpHandler) {
    if (!!token && this.isSameOriginUrl(req)) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(req);
  }

  private isSameOriginUrl(req: any) {
    // It's an absolute url with the same origin.
    if (req.url.startsWith(`${window.location.origin}/`)) {
      return true;
    }

    // It's a protocol relative url with the same origin.
    // For example: //www.example.com/api/Products
    if (req.url.startsWith(`//${window.location.host}/`)) {
      return true;
    }

    // It's a relative url like /api/Products
    if (/^\/[^\/].*/.test(req.url)) {
      return true;
    }

    // It's an absolute or protocol relative url that
    // doesn't have the same origin.
    return false;
  }
}
function from(arg0: any): Observable<HttpEvent<any>> {
  throw new Error('Function not implemented.');
}

function throwError() {
  throw new Error('Function not implemented.');
}

