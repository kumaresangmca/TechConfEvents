import { Component, OnInit } from '@angular/core';
import { OrganizationDTO } from 'src/app/shared/dto/organizationDTO';
import { AuthService } from 'src/app/shared/service/auth/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  organization: OrganizationDTO = {} as OrganizationDTO;
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.organization = this.authService.GetOrganizationDetails();
  }


}
