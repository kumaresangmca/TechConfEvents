import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ApiUrl } from '../../constant/api.constant';
import { ResultDTO } from '../../dto/resultDto';
import { OrganizationDTO } from '../../dto/organizationDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private router: Router, private http: HttpClient) {}

  IsAuthendicated(): boolean {
    if (sessionStorage.getItem('organizationDetails')) {
      return true;
    }
    return false;
  }

  Login(code: string): Observable<boolean> {
    return new Observable((observer) => {
      this.http
        .get(ApiUrl.organizationsByCode.replace('{code}', code))
        .subscribe(
          (data: ResultDTO) => {
            const organizations = data?.results as OrganizationDTO;
            if (organizations) {
              sessionStorage.setItem(
                'organizationDetails',
                JSON.stringify(organizations)
              );
              observer.next(true);
            } else {
              observer.next(false);
            }
            observer.complete();
          },
          (error: HttpErrorResponse) => {
            observer.next(false);
            observer.complete();
          }
        );
    });
  }

  Logout() {
    sessionStorage.clear();
    this.router.navigate(['login']);
  }
  GetOrganizationDetails(): OrganizationDTO {
    let organization = {} as OrganizationDTO;
    const sessionDetails = sessionStorage.getItem('organizationDetails');
    if (sessionDetails) {
      organization = JSON.parse(sessionDetails) as OrganizationDTO;
    }
    return organization;
  }
}
