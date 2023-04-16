import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpEvent,
  HttpHandler,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../service/auth/auth.service';
import { LoaderService } from '../service/loader/loader.service';

@Injectable({ providedIn: 'root' })
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService,
              private loaderService: LoaderService) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (this.authService.IsAuthendicated()) {
      let OrganizationDTO = this.authService.GetOrganizationDetails();
      req = req.clone({ setHeaders: { apiKey: OrganizationDTO.apiKey } });
    }
    this.loaderService.loader.next(true);
    return new Observable(observer => {
      next.handle(req).subscribe(
        s => {
          this.loaderService.loader.next(false);
          observer.next(s);
          // observer.complete();
        },
        e => {
          this.loaderService.loader.next(false);
          observer.next(e);
          // observer.complete();
        }
      )
    });
  }
}
